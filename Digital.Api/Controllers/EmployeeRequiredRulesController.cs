using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Digital.Api.Data;
using Digital.Api.Models;

namespace Digital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRequiredRulesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeRequiredRulesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeRequiredRules
        [HttpGet]
        public async Task<ActionResult<EmployeeRequiredRule>> GetRules()
        {
            var rules = await _context.EmployeeRequiredRules.FirstOrDefaultAsync(r => r.Id == 1);
            if (rules == null)
            {
                rules = new EmployeeRequiredRule
                {
                    Id = 1,
                    FullName = true,
                    OfficialEmail = true,
                    EmployeeCode = false,
                    DateOfJoining = true,
                    Department = true,
                    Location = false,
                    Designation = true,
                    AnnualSalary = false,
                    CoreQualification = true,
                    Remarks = false,
                    DateOfBirth = true,
                    Gender = true,
                    MaritalStatus = true,
                    BloodGroup = true,
                    Religion = false,
                    Category = true,
                    MobileNumber = true,
                    AlternateNumber = false,
                    CurrentAddress = true,
                    PermanentAddress = true,
                    Photo = true,
                    AadharNumber = true,
                    PanNumber = true,
                    UanNumber = false,
                    EsicNumber = false,
                    PassportNumber = false,
                    PvcNumber = false,
                    BankDetails = true,
                    EmergencyName = true,
                    EmergencyPhone = true,
                    EmergencyRelation = true,
                    NomineeDetails = false
                };
                _context.EmployeeRequiredRules.Add(rules);
                await _context.SaveChangesAsync();
            }
            return rules;
        }

        // POST: api/EmployeeRequiredRules
        [HttpPost]
        public async Task<IActionResult> UpdateRules([FromBody] EmployeeRequiredRule updatedRules)
        {
            var rules = await _context.EmployeeRequiredRules.FirstOrDefaultAsync(r => r.Id == 1);
            if (rules == null)
            {
                updatedRules.Id = 1;
                _context.EmployeeRequiredRules.Add(updatedRules);
            }
            else
            {
                rules.FullName = updatedRules.FullName;
                rules.OfficialEmail = updatedRules.OfficialEmail;
                rules.EmployeeCode = updatedRules.EmployeeCode;
                rules.DateOfJoining = updatedRules.DateOfJoining;
                rules.Department = updatedRules.Department;
                rules.Location = updatedRules.Location;
                rules.Designation = updatedRules.Designation;
                rules.AnnualSalary = updatedRules.AnnualSalary;
                rules.CoreQualification = updatedRules.CoreQualification;
                rules.Remarks = updatedRules.Remarks;

                rules.DateOfBirth = updatedRules.DateOfBirth;
                rules.Gender = updatedRules.Gender;
                rules.MaritalStatus = updatedRules.MaritalStatus;
                rules.BloodGroup = updatedRules.BloodGroup;
                rules.Religion = updatedRules.Religion;
                rules.Category = updatedRules.Category;
                rules.MobileNumber = updatedRules.MobileNumber;
                rules.AlternateNumber = updatedRules.AlternateNumber;

                rules.CurrentAddress = updatedRules.CurrentAddress;
                rules.PermanentAddress = updatedRules.PermanentAddress;

                rules.Photo = updatedRules.Photo;
                rules.AadharNumber = updatedRules.AadharNumber;
                rules.PanNumber = updatedRules.PanNumber;
                rules.UanNumber = updatedRules.UanNumber;
                rules.EsicNumber = updatedRules.EsicNumber;
                rules.PassportNumber = updatedRules.PassportNumber;
                rules.PvcNumber = updatedRules.PvcNumber;

                rules.BankDetails = updatedRules.BankDetails;

                rules.EmergencyName = updatedRules.EmergencyName;
                rules.EmergencyPhone = updatedRules.EmergencyPhone;
                rules.EmergencyRelation = updatedRules.EmergencyRelation;
                rules.NomineeDetails = updatedRules.NomineeDetails;

                _context.Entry(rules).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return Ok(rules);
        }
    }
}
