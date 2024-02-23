using AutoMapper;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>();
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
