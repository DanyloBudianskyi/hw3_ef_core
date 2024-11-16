using hw3_ef_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3_ef_core
{
    public class Service : IDisposable
    {
        public ProjectManager _db {  get; set; }
        public Service(ProjectManager db) {
            _db = db;
        }

        public void AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
            }
        }
        public void RemoveEmployee(int id)
        {
            var EmpToDelete = _db.Employees.Find(id);
            if (EmpToDelete != null)
            {
                _db.Employees.Remove(EmpToDelete);
                _db.SaveChanges();
            }
        }
        public ICollection<Employee> ReadEmployee()
        {
            return _db.Employees.ToList();
        }
        public void UpdateEmployee(int id, Employee employee)
        {
            var EmpToUpdate = _db.Employees.Find(id);
            if (EmpToUpdate != null)
            {
                EmpToUpdate.TeamId = employee.TeamId;
                EmpToUpdate.Team = employee.Team;
                EmpToUpdate.Name = employee.Name;
                EmpToUpdate.Projects = employee.Projects;
                EmpToUpdate.Tasks = employee.Tasks;
                _db.SaveChanges();
            }
        }

        public void AddProject(Project project)
        {
            if (project != null)
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
            }
        }
        public void RemoveProject(int id)
        {
            var ProjectToDelete = _db.Projects.Find(id);
            if (ProjectToDelete != null)
            {
                _db.Projects.Remove(ProjectToDelete);
                _db.SaveChanges();
            }
        }
        public ICollection<Project> ReadProjects()
        {
            return (ICollection<Project>)_db.Projects;
        }
        public void UpdateProject(int id, Project project)
        {
            var ProjectToUpdate = _db.Projects.Find(id);
            if (ProjectToUpdate != null)
            {
                ProjectToUpdate.Tasks = project.Tasks;
                ProjectToUpdate.Team = project.Team;
                ProjectToUpdate.TeamId = project.TeamId;
                ProjectToUpdate.Title = project.Title;
                ProjectToUpdate.Employees = project.Employees;
                _db.SaveChanges();
            }
        }

        public void AddTask(Models.Task task)
        {
            if (task != null)
            {
                _db.Tasks.Add(task);
                _db.SaveChanges();
            }
        }
        public void RemoveTask(int id)
        {
            var TaskToDelete = _db.Tasks.Find(id);
            if (TaskToDelete != null)
            {
                if (TaskToDelete.Detail != null)
                {
                    _db.TaskDetails.Remove(TaskToDelete.Detail);
                }
                _db.Tasks.Remove(TaskToDelete);
                _db.SaveChanges();
            }
        }
        public ICollection<Models.Task> ReadTasks()
        {
            return (ICollection<Models.Task>)_db.Tasks;
        }
        public void UpdateTask(int id, Models.Task task)
        {
            var TaskToUpdate = _db.Tasks.Find(id);
            if (TaskToUpdate != null)
            {
                TaskToUpdate.Name = task.Name;
                TaskToUpdate.IsCompleted = task.IsCompleted;
                TaskToUpdate.EmployeeId = task.EmployeeId;
                TaskToUpdate.Employee = task.Employee;
                TaskToUpdate.ProjectId = task.ProjectId;
                TaskToUpdate.Project = task.Project;
                TaskToUpdate.Detail = task.Detail;
                _db.SaveChanges();
            }
        }

        public void AddTeam(Team team)
        {
            if (team != null)
            {
                _db.Teams.Add(team);
                _db.SaveChanges();
            }
        }
        public void RemoveTeam(int id)
        {
            var TeamToDelete = _db.Teams.Find(id);
            if (TeamToDelete != null)
            {
                _db.Teams.Remove(TeamToDelete);
                _db.SaveChanges();
            }
        }
        public ICollection<Team> ReadTeams()
        {
            return (ICollection<Team>)_db.Teams;
        }
        public void UpdateTeam(int id, Team team)
        {
            var TeamToUpdate = _db.Teams.Find(id);
            if (TeamToUpdate != null)
            {
                TeamToUpdate.Name = team.Name;
                TeamToUpdate.Employees = team.Employees;
                TeamToUpdate.Projects = team.Projects;
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
