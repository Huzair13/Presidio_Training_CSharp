using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    public class RequestController : ControllerBase
    {
        private readonly IRequestRaiseServices _requestServices;

        public RequestController(IRequestRaiseServices requestServices)
        {
            _requestServices = requestServices;
        }

        [Authorize]
        [HttpPost("RaiseRequest")]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Request>> RaiseRequest([FromBody] RaiseRequestInputDTO raiseRequestInputDTO)
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);
                RaiseRequestDTO raiseRequestDTO = new RaiseRequestDTO();

                raiseRequestDTO.RequestRaisedBy = Convert.ToInt32(employeeId);
                raiseRequestDTO.RequestMessage = raiseRequestInputDTO.RequestMessage;

                var result = await _requestServices.RaiseRequestAsync(raiseRequestDTO);
                return Ok(result);
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(new ErrorModel(404, nefe.Message));
                //return NotFound(nefe.Message);
            }
            catch(NotLoggedInException nlex)
            {
                return NotFound(new ErrorModel(501, nlex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(501, ex.Message));
            }
        }

        [Authorize]
        [HttpGet("GetRequests")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> GetRequest()
        {
            try
            {
                var employeeId = User.FindFirstValue(ClaimTypes.Name);

                var result = await _requestServices.GetRequestsByEmployeeIDAsync(Convert.ToInt32(employeeId));
                return Ok(result);
            }
            catch(NoRequestFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(501, ex.Message));
            }
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("GetAllRequests")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> GetAllRequests()
        {
            try
            {
                var result = await _requestServices.GetAllRequestAsyc();
                var orderedResult = result.OrderByDescending(s => s.RequestStatus == "Open")
                                            .ThenBy(r => r.RequestDate);
                return Ok(orderedResult);
            }
            catch (NoRequestFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(501, ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("CloseRequest")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> CloseRequest([FromBody] CloseRequestInputDTO closeRequestInputDTO)
        {
            try
            {
                var employeeID = User.FindFirstValue(ClaimTypes.Name);

                CloseRequestDTO closeRequestDTO = new CloseRequestDTO();
                closeRequestDTO.RequestID = closeRequestInputDTO.RequestId;
                closeRequestDTO.RequestClosedBy = Convert.ToInt32(employeeID);

                var result = await _requestServices.CloseRequestAsync(closeRequestDTO);
                return Ok(result);
            }
            catch (NoRequestFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(501, ex.Message));
            }
        }
    }
}
