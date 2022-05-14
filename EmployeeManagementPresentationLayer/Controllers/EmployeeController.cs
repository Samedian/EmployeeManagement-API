using EmployeeManagementBusinessLayer;
using EmployeeManagementEntity;
using EmployeeManagementException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeManagementPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeBAL _employeeBAL;
        private readonly IValidateData _validateData;
        public EmployeeController(IEmployeeBAL employeeBAL,IValidateData validateData)
        {
            _employeeBAL = employeeBAL;
            _validateData = validateData;
        }

        /// <summary>
        /// Give list of employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<EmployeeDetailsEntity> EmployeeEntity = await _employeeBAL.GetEmployee();
                if (EmployeeEntity.Count == 0)
                    return NotFound("No List Found");

                return Ok(EmployeeEntity);
            }
            catch(BadRequest ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Unable to connect Sql Server"))
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                else
                    return BadRequest(ex.Message);
            }
            catch (System.Net.WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return NotFound("Server Not Found");

                    case HttpStatusCode.InternalServerError:
                        return StatusCode((int)HttpStatusCode.InternalServerError);

                    default:
                        return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetStudent")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                List<EmployeeDetailsEntity> EmployeeEntity = await _employeeBAL.GetEmployee();

                var _Employee = EmployeeEntity.Find(s => s.Id.Equals(id));

                if (_Employee == null)
                    return NotFound("No List Found");

                return Ok(_Employee);
            }
            catch (BadRequest ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Unable to connect Sql Server"))
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                else
                    return BadRequest(ex.Message);
            }
            catch (System.Net.WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return NotFound("Server Not Found");

                    case HttpStatusCode.InternalServerError:
                        return StatusCode((int)HttpStatusCode.InternalServerError);

                    default:
                        return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Save Employee 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Save(EmployeeDetailsEntity employee)
        {
            try
            {
                bool result = await _employeeBAL.AddEmployee(employee);

                if (result)
                    return Created("Employee Added ", employee);

                return BadRequest();

            }
            catch(BadRequest ex)
            {
                return BadRequest(ex.Message);

            }catch(SqlException ex)
            {
                if (ex.Message.Contains("Unable to connect Sql Server"))
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                else
                    return BadRequest(ex.Message);
            }
            catch (System.Net.WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return NotFound("Server Not Found");

                    case HttpStatusCode.InternalServerError:
                        return StatusCode((int)HttpStatusCode.InternalServerError);

                    default:
                        return StatusCode((int)response.StatusCode);
                }
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            try
            {
                bool result = await _employeeBAL.DeleteEmployee(id);

                if (result)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (BadRequest ex)
            {
                return BadRequest(ex.Message);

            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Unable to connect Sql Server"))
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                else
                    return BadRequest(ex.Message);
            }
            catch (System.Net.WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return NotFound("Server Not Found");

                    case HttpStatusCode.InternalServerError:
                        return StatusCode((int)HttpStatusCode.InternalServerError);

                    default:
                        return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        
    }
}
