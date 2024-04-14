using CrudOperationMVC.DAL;
using CrudOperationMVC.Models;
using CrudOperationMVC.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDBContext _con;

        public StudentController(StudentDBContext con)
        {
            this._con = con;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var student=_con.Students.ToList();//students in used to communicate with database
            List<StudentViewModel> studentList = new List<StudentViewModel>();

            if (student!=null) 
            {
                foreach (var stud in student)
                {
                    var StudentViewModel = new StudentViewModel()
                    {
                        StudId=stud.StudId,
                        FirstName=stud.FirstName,
                        LastName=stud.LastName,
                        DateOfBirth=stud.DateOfBirth,
                        Email=stud.Email,
                        Stream=stud.Stream,
                        Subjects=stud.Subjects,
                        Marks=stud.Marks,
                    };
                    studentList.Add(StudentViewModel);
                }
                return View(studentList);
            }
            return View(studentList);
       }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        FirstName = studentData.FirstName,
                        LastName = studentData.LastName,
                        DateOfBirth = studentData.DateOfBirth,
                        Email = studentData.Email,
                        Stream = studentData.Stream,
                        Subjects = studentData.Subjects,
                        Marks = studentData.Marks,

                    };
                    _con.Students.Add(student);
                    _con.SaveChanges();// save changes on tha database
                    TempData["successmsg"] = "Student record added successfully.";
                    return RedirectToAction("Index");//redirt in a any action in same controller to use a redirect to Action method 
                }
                else
                {
                    TempData["errmsg"] = "Model data is not valid.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errmsg"] = ex.Message;
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Edit(int Id) {
            try
            {
                var student = _con.Students.SingleOrDefault(x => x.StudId == Id);
                if (student != null)
                {
                    var studentView = new StudentViewModel()
                    {
                        StudId = student.StudId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth,
                        Email = student.Email,
                        Stream = student.Stream,
                        Subjects = student.Subjects,
                        Marks = student.Marks,

                    };
                    return View(studentView);
                }
                else
                {
                    TempData["errmsg"] = $" student details not available with the id:{Id}";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                TempData["errmsg"] = ex.Message;
                return RedirectToAction("Index");
            }
           
        }
        [HttpPost]
        public IActionResult Edit(StudentViewModel model)// this view model is responsible for pass the data from thi controller to view and view to controller
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student() //this  student class is responsible to communicate from the database
                    {
                        StudId = model.StudId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        Email = model.Email,
                        Stream = model.Stream,
                        Subjects = model.Subjects,
                        Marks = model.Marks,
                    };
                    _con.Students.Update(student);
                    _con.SaveChanges();
                    TempData["successmsg"] = "Student details updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errmsg"] = "Model dat is invalid";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                TempData["errmsg"] = ex.Message;
                return View();
            }
           
        }

    }
}
