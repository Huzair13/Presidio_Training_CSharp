using RequestTrackerBL;
using RequestTrackerDALLibrary.Exceptions;
using RequestTrackerLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApp
{
    public class AdminFrontend :IFrontend
    {
        private static Employee LoggedInEmployee;

        public AdminFrontend(Employee loggedInEmployee)
        {
            LoggedInEmployee = loggedInEmployee;
        }

        //DISPLAY MENY FUNCTION 
        public async Task DisplayMenu()
        {
            // Menu loop
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Raise a Request");
                Console.WriteLine("2. View All Request Status");
                Console.WriteLine("3. View All Solutions");
                Console.WriteLine("4. View Status for Requests Raised by you");
                Console.WriteLine("5. View Solutions for Requests Raised by you");
                Console.WriteLine("6. Give Feedback for your Requests");
                Console.WriteLine("7. Respond to Solution for your Request");
                Console.WriteLine("8. Provide Solution to the Open Requests");
                Console.WriteLine("9. Mark Requests as Closed");
                Console.WriteLine("10. View Feedbacks for you");
                Console.WriteLine("11. Change roles for the users");
                Console.WriteLine("12. Log Out");
                Console.Write("Enter your choice (1-12): ");


                //CHOICE INPUT
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        await GetRequestRaiseDetails();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "2":
                        await ViewRequestStatus();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "3":
                        await ViewSolutions();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "4":
                        await ViewRequestStatusRaisedByAdmin();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "5":
                        await ViewSolutionsForAdminRequest();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "6":
                        await GetFeedbackDetailsForFeedbackToRequest();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "7":
                        await RespondToSolutionFromRequest();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "8":
                        await GetRequestSolutionDetails();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "9":
                        await GetCloseRequestDetails();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "10":
                        await ViewFeedbacks();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "11":
                        await ChangeRolesForUsers();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "12":
                        exit = true;
                        break;
                    default:
                        await Console.Out.WriteLineAsync("Invalid choice. Please enter a number between 1 and 12");
                        break;
                }
            }
        }

        //1) RAISE REQUEST DETAILS INPUT
        public async Task GetRequestRaiseDetails()
        {
            await Console.Out.WriteLineAsync("Please enter the Request");
            string request = Console.ReadLine();

            int requestRaisedBy = LoggedInEmployee.Id;

            string requestStatus = "Open";
            DateTime requestDate = DateTime.Now;


            await RaiseRequest(request, requestDate, requestRaisedBy, requestStatus);
        }

        //1) RAISE REQUEST
        public async Task RaiseRequest(string requestMessage, DateTime requestDate, int requestRaisedBy, string requestStatus)
        {
            await Console.Out.WriteLineAsync($"Request Raised By : {requestRaisedBy}");
            Request NewRequest = new Request()
            {
                RequestMessage = requestMessage,
                RequestDate = requestDate
                ,
                RequestRaisedBy = requestRaisedBy,
                RequestStatus = requestStatus
            };
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();

            var result = await requestRaiseBL.RaiseRequestAsync(NewRequest);
            if (result != null)
            {
                await Console.Out.WriteLineAsync($"Request Raised Successfully and the Request Number is {result.RequestNumber}");
            }

        }

        //2) VIEW REQUEST STATUS
        public async Task ViewRequestStatus()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            var requests = await requestRaiseBL.GetAllRequestAsyc();

            Console.WriteLine("All Requests and their current status");
            Console.WriteLine("Request ID".PadRight(15) + "Request Message".PadRight(50) + "Status");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (var request in requests)
            {
                Console.WriteLine($"{request.RequestNumber}".PadRight(15) + $"{request.RequestMessage}".PadRight(50) + $"{request.RequestStatus}");
            }
        }

        //3)VIEW SOLUTIONS

        private async Task ViewSolutions()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
            var allRequests = await requestRaiseBL.GetAllRequestAsyc();
            var allSolutions = await requestSolutionBL.GetAllSolutionsAsync();

            Console.WriteLine("-----All Solutions-----");
            Console.WriteLine("Request ID".PadRight(15) + "Request Message".PadRight(50) + "Solution Description".PadRight(50) + "Request Status");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------");

            foreach (var request in allRequests)
            {
                var solutionForReq = allSolutions.FirstOrDefault(r => r.RequestId == request.RequestNumber);
                Console.WriteLine($"{request.RequestNumber}".PadRight(15) + $"{request.RequestMessage}".PadRight(50) + $"{solutionForReq?.SolutionDescription ?? "No Solutions"}".PadRight(50) + $"{request.RequestStatus}");
            }
            Console.WriteLine();
        }

        //4) VIEW REQUEST STATUS (ONLY RAISED BY HIM)
        public async Task ViewRequestStatusRaisedByAdmin()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            var requests = await requestRaiseBL.GetRequestsByEmployeeIDAsync(LoggedInEmployee.Id);

            if (requests.Count > 0)
            {
                await Console.Out.WriteLineAsync("All Requests Raised By you");
                await Console.Out.WriteLineAsync("Request ID \t Request \t Request Status");
                await Console.Out.WriteLineAsync("------------------------------------------------------------------");

                foreach (var request in requests)
                {
                    int staticLength = 30;
                    int len = request.RequestMessage.Length;
                    int spaceLen = staticLength - len;

                    Console.WriteLine($"{request.RequestNumber} \t {request.RequestMessage} {new string(' ', spaceLen)} \t {request.RequestStatus}");
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("You Not Raised Any Requests");
            }

            await Console.Out.WriteLineAsync();
        }

        //5) VIEW SOLUTIONS (FOR REQUESTS RAISED BY HIM)
        private async Task ViewSolutionsForAdminRequest()
        {
            try
            {
                RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
                var requests = await requestRaiseBL.GetRequestsByEmployeeIDAsync(LoggedInEmployee.Id);
                if (requests.Count > 0)
                {
                    await Console.Out.WriteLineAsync("All Closed Requests Raised By you");
                    await Console.Out.WriteLineAsync("Request ID \t Request");
                    await Console.Out.WriteLineAsync("----------------------------------");

                    foreach (var request in requests)
                    {
                        if (request.RequestStatus == "Closed")
                        {
                            await Console.Out.WriteLineAsync($"{request.RequestNumber} \t {request.RequestMessage}");
                        }
                        //Console.WriteLine($"{request.RequestNumber} \t {request.RequestMessage}");
                    }

                    await Console.Out.WriteAsync("Please Enter the Request ID to view the Request Solution for the particular closed request : ");
                    int requestID = Convert.ToInt32(Console.ReadLine());

                    RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
                    RequestSolution solution = await requestSolutionBL.GetSolutionByRequestId(requestID);
                    //Console.WriteLine("Solution ID \t Solution Descripton \t  Solution SolvedBy \t Solution Solved Date \t Solution IsSolved \t Request Raiser Comments");
                    //Console.WriteLine($"{solution.SolutionId} \t {solution.SolutionDescription} \t {solution.SolvedBy}\t {solution.SolvedDate} \t {solution.IsSolved} \t {solution?.RequestRaiserComment ?? "No Comments"}");
                    // Inside your method where you print the solution details:
                    await Console.Out.WriteLineAsync();
                    await Console.Out.WriteLineAsync("Solution ID".PadRight(15) + "Solution Description".PadRight(25) + "Solved By".PadRight(10) + "Solved Date".PadRight(25) + "Is Solved".PadRight(10) + "Request Raiser Comments".PadRight(25));
                    await Console.Out.WriteLineAsync($"{solution.SolutionId}".PadRight(15) + $"{solution.SolutionDescription}".PadRight(25) + $"{solution.SolvedBy}".PadRight(10) + $"{solution.SolvedDate}".PadRight(25) + $"{solution.IsSolved}".PadRight(10) + $"{solution?.RequestRaiserComment ?? "No Comments"}".PadRight(25));


                    await adminMenuForRequestResponseAndFeedback(requestID, solution);
                }
                else
                {
                    await Console.Out.WriteLineAsync("You Not Raised Any Requests Yet");
                }
            }
            catch (InValidIdException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }


        }

        //5)
        public async Task adminMenuForRequestResponseAndFeedback(int requestID, RequestSolution solution)
        {
            bool exit = false;
            while (!exit)
            {
                await Console.Out.WriteLineAsync($"Operations on the Request ID : {requestID}");
                await Console.Out.WriteLineAsync("1. Give Feedback");
                await Console.Out.WriteLineAsync("2. Respond to the Solution");
                await Console.Out.WriteLineAsync("3. Exit to the Main Menu");
                await Console.Out.WriteAsync("Enter your choice (1-3): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await GetFeedbackDetails(solution);
                        await Console.Out.WriteLineAsync();
                        break;
                    case "2":
                        await RespondToSolution(requestID, solution);
                        await Console.Out.WriteLineAsync();
                        break;
                    case "3":
                        exit = true;
                        await Console.Out.WriteLineAsync();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3");
                        await Console.Out.WriteLineAsync();
                        break;
                }
            }
        }

        //5)
        private async Task GetFeedbackDetails(RequestSolution solution)
        {
            int solutionId = solution.SolutionId;

            await Console.Out.WriteLineAsync($"Please enter the Remarks for the Solution ID {solutionId}");
            string remarks = Console.ReadLine();

            await Console.Out.WriteLineAsync("Please enter the rating");
            float ratings = float.Parse(Console.ReadLine());

            int feedbackBy = LoggedInEmployee.Id;
            DateTime feedbackDate = DateTime.Now;

            await AddFeedbackToSolution(solutionId, remarks, ratings, feedbackBy, feedbackDate);

        }

        //5)
        private async Task AddFeedbackToSolution(int solutionId, string? remarks, float ratings, int feedbackBy, DateTime feedbackDate)
        {
            SolutionFeedback feedback = new SolutionFeedback()
            {
                SolutionId = solutionId,
                Remarks = remarks,
                FeedbackBy = feedbackBy,
                Rating = ratings,
                FeedbackDate = feedbackDate
            };

            FeedbackBL feedbackBL = new FeedbackBL();
            await feedbackBL.AddFeedback(feedback);
        }

        //5)
        private async Task RespondToSolution(int requestID, RequestSolution solution)
        {
            await Console.Out.WriteLineAsync($"Please enter the your Response to the Solution ID {solution.SolutionId}");
            string response = Console.ReadLine();

            solution.RequestRaiserComment = response;

            RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
            requestSolutionBL.AddCommentsToTheSolutions(requestID, solution.SolutionId, response);
        }


        //6) Give Feedback (For Request Raised by him)
        private async Task GetFeedbackDetailsForFeedbackToRequest()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
            var allRequestsByAdmin = await requestRaiseBL.GetRequestsByEmployeeIDAsync(LoggedInEmployee.Id);

            if (allRequestsByAdmin.Count > 0)
            {
                await Console.Out.WriteLineAsync("All Closed Requests Raised by You");
                await Console.Out.WriteLineAsync("Request ID".PadRight(15) + "Request Message".PadRight(30) + "Solution Description");
                await Console.Out.WriteLineAsync("-----------------------------------------------------------------------------------------------");

                foreach (var request in allRequestsByAdmin)
                {
                    try
                    {
                        var solutionFoReq = await requestSolutionBL.GetSolutionByRequestId(request.RequestNumber);
                        await Console.Out.WriteLineAsync($"{request.RequestNumber}".PadRight(15) + $"{request.RequestMessage}".PadRight(30) + $"{(solutionFoReq?.SolutionDescription ?? "No Solutions")}");
                    }
                    catch (InValidIdException ex)
                    {

                    }

                }

                await Console.Out.WriteLineAsync("To Give Feedback to the Solution Please Enter the Request ID from the above list");
                int requestID = Convert.ToInt32(Console.ReadLine());

                try
                {
                    var solutionForInputReq = await requestSolutionBL.GetSolutionByRequestId(requestID);
                    await Console.Out.WriteAsync($"Please enter the Remarks for the Solution ID {solutionForInputReq.SolutionId} : ");
                    string remarks = Console.ReadLine();

                    await Console.Out.WriteAsync("Please enter the rating : ");
                    float ratings = float.Parse(Console.ReadLine());

                    await Console.Out.WriteLineAsync();
                    int feedbackBy = LoggedInEmployee.Id;
                    DateTime feedbackDate = DateTime.Now;

                    await AddFeedbackToSolution(solutionForInputReq.SolutionId, remarks, ratings, feedbackBy, feedbackDate);
                }
                catch (InValidIdException ex)
                {
                    await Console.Out.WriteLineAsync("Entered Invalid ID");
                }


            }
            else
            {
                await Console.Out.WriteLineAsync("You dont have any Requests to give Feedback ");
            }

        }

        //7) RESPOND TO SOLUTION ( FOR REQUEST RAISED BY HIM)
        private async Task RespondToSolutionFromRequest()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
            var allRequestsByAdmin = await requestRaiseBL.GetRequestsByEmployeeIDAsync(LoggedInEmployee.Id);

            if (allRequestsByAdmin.Count > 0)
            {
                if (allRequestsByAdmin != null)
                {
                    await Console.Out.WriteLineAsync("All Closed Requests Raised by You");
                    await Console.Out.WriteLineAsync("Request ID".PadRight(15) + "Request Message".PadRight(30) + "Solution Description");
                    await Console.Out.WriteLineAsync("---------------------------------------------------------------------------------------------------");

                    foreach (var request in allRequestsByAdmin)
                    {
                        try
                        {
                            var solutionFoReq = await requestSolutionBL.GetSolutionByRequestId(request.RequestNumber);
                            await Console.Out.WriteLineAsync($"{request.RequestNumber}".PadRight(15) + $"{request.RequestMessage}".PadRight(30) + $"{(solutionFoReq?.SolutionDescription ?? "No Solutions")}");
                        }
                        catch (InValidIdException ex)
                        {

                        }

                    }

                    await Console.Out.WriteAsync("To Respond to the Solution Please Enter the Request ID from the above list : ");
                    int requestID = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var solutionForInputReq = await requestSolutionBL.GetSolutionByRequestId(requestID);
                        await Console.Out.WriteAsync($"Please enter your response to the Solution ID {solutionForInputReq.SolutionId} : ");
                        await Console.Out.WriteLineAsync();
                        string response = Console.ReadLine();

                        solutionForInputReq.RequestRaiserComment = response;
                        requestSolutionBL.AddCommentsToTheSolutions(requestID, solutionForInputReq.SolutionId, response);
                    }
                    catch (InValidIdException ex)
                    {

                    }
                }
                else
                {
                    await Console.Out.WriteLineAsync("No Requests Raised yet");
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("You Did not Raised any Requests");
            }
        }

        //8)
        async Task GetRequestSolutionDetails()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
            var allRequests = await requestRaiseBL.GetAllRequestAsyc();
            var allSolutions = await requestSolutionBL.GetAllSolutionsAsync();

            Console.WriteLine("-----All Solutions-----");
            Console.WriteLine("Request ID".PadRight(15) + "Request Message".PadRight(80) + "Solution Description".PadRight(50) + "Request Status");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (var request in allRequests)
            {
                var solutionForReq = allSolutions.FirstOrDefault(r => r.RequestId == request.RequestNumber);
                if (request.RequestStatus == "Open")
                {
                    Console.WriteLine($"{request.RequestNumber}".PadRight(15) + $"{request.RequestMessage}".PadRight(80) + $"{solutionForReq?.SolutionDescription ?? "No Solutions"}".PadRight(50) + $"{request.RequestStatus}");
                }
            }
            Console.WriteLine();


            await Console.Out.WriteAsync("Please enter Request Id from the aboe list to give solution : ");
            int requestId = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteAsync("Please enter Solution Description : ");
            string solutionDescription = Console.ReadLine();
            await Console.Out.WriteLineAsync();

            int solvedBy = LoggedInEmployee.Id;
            bool isSolved = true;
            DateTime solvedDate = DateTime.Now;

            await GiveSolutionToRequest(requestId, solutionDescription, solvedBy, isSolved, solvedDate);

        }

        //8) GIVE SOLUTION TO REQUESTS
        async Task GiveSolutionToRequest(int requestId, string? solutionDescription, int solvedBy, bool isSolved, DateTime solvedDate)
        {
            try
            {
                RequestRaiseBL requestRaiseBL = new RequestRaiseBL();

                var requests = requestRaiseBL.GetRequestByRquestId(requestId);
                if (requests != null)
                {
                    RequestSolution requestSolution = new RequestSolution()
                    {
                        RequestId = requestId,
                        SolutionDescription = solutionDescription,
                        SolvedBy = solvedBy,
                        IsSolved = isSolved,
                        SolvedDate = solvedDate,
                    };
                    RequestSolutionBL requestSolutionBL = new RequestSolutionBL();

                    await requestSolutionBL.GiveSolutionToRequestAsync(requestSolution);
                    await requestRaiseBL.CloseRequestAsync(requestId, LoggedInEmployee.Id);
                }
                else
                {
                    await Console.Out.WriteLineAsync("Invalid ID entered");
                }

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        //9)
        async Task CloseRequest(int requestID)
        {
            try
            {
                RequestRaiseBL requestRaiseBL = new RequestRaiseBL();

                var result = await requestRaiseBL.CloseRequestAsync(requestID, LoggedInEmployee.Id);
                if (result != null)
                {
                    await Console.Out.WriteLineAsync($"Current Status of the Request ID {requestID} is {result.RequestStatus}");
                }
                await Console.Out.WriteLineAsync();

                await Console.Out.WriteLineAsync("Request Closed Successfully");
            }
            catch (RequestNotFoundException ex)
            {
                await Console.Out.WriteLineAsync($"RequestNotFoundException : {ex.Message}");
            }
        }

        //9) CLOSE THE REQUESTS
        async Task GetCloseRequestDetails()
        {
            await ViewRequestStatus();
            await Console.Out.WriteLineAsync("Please enter Request Id to close from the above list");
            int requestId = Convert.ToInt32(Console.ReadLine());
            await CloseRequest(requestId);

            bool exit = false;
            await Console.Out.WriteLineAsync();
            await Console.Out.WriteLineAsync($"Operations on the Request ID : {requestId}");
            await Console.Out.WriteLineAsync("1. Give Solution");
            await Console.Out.WriteLineAsync("2. Exit to the Main Menu");
            await Console.Out.WriteAsync("Enter your choice (1-2): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await GetRequestSolutionDetailsForTheClosedReq(requestId);
                    await Console.Out.WriteLineAsync();
                    break;
                case "2":
                    exit = true;
                    await Console.Out.WriteLineAsync();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 2");
                    await Console.Out.WriteLineAsync();
                    break;
            }
        }

        //9)
        private async Task GetRequestSolutionDetailsForTheClosedReq(int requestId)
        {
            await Console.Out.WriteLineAsync("Please enter Solution Description");
            string solutionDescription = Console.ReadLine();

            int solvedBy = LoggedInEmployee.Id;
            bool isSolved = true;
            DateTime solvedDate = DateTime.Now;

            await GiveSolutionToRequest(requestId, solutionDescription, solvedBy, isSolved, solvedDate);
            await Console.Out.WriteLineAsync("Solution Given Successfully");
            await Console.Out.WriteLineAsync();
        }

        //10) VIEW FEEDBACKS

        private async Task ViewFeedbacks()
        {
            try
            {
                RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
                RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
                FeedbackBL feedbackBL = new FeedbackBL();
                var requestsByAdmin = await requestRaiseBL.GetRequestsByEmployeeIDAsync(LoggedInEmployee.Id);

                await Console.Out.WriteLineAsync("Solution ID".PadRight(15) + "Solution Description".PadRight(30) + "FeedbackID".PadRight(15) + "Remarks".PadRight(20) + "Rating");

                foreach (var request in requestsByAdmin)
                {
                    try
                    {
                        var solution = await requestSolutionBL.GetSolutionByRequestId(request.RequestNumber);

                        if (solution != null)
                        {
                            if (solution.IsSolved && solution.SolvedBy == LoggedInEmployee.Id)
                            {
                                try
                                {
                                    var feedbacksBySolutionID = await feedbackBL.GetFeedbackBySolutionId(solution.SolutionId);
                                    await Console.Out.WriteLineAsync($"{feedbacksBySolutionID.SolutionId}".PadRight(15) + $"{solution.SolutionDescription}".PadRight(30) + $"{feedbacksBySolutionID.FeedbackId}".PadRight(15) + $"{feedbacksBySolutionID?.Remarks ?? "No Feedback"}".PadRight(20) + $"{feedbacksBySolutionID.Rating}");
                                }
                                catch (InValidIdException ex)
                                {

                                }

                            }
                        }

                    }
                    catch (InValidIdException ex)
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }


        //11)CHANGE ROLES FOR USERS
        private async Task ChangeRolesForUsers()
        {
            try
            {
                EmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();

                await Console.Out.WriteLineAsync("Enter the UserID to Change the role");
                int userId = Convert.ToInt32(Console.ReadLine());

                var employeeDetails = await employeeLoginBL.getUserDetails(userId);
                await Console.Out.WriteLineAsync("userID".PadRight(10) + "UserName".PadRight(20) + "Role");
                await Console.Out.WriteLineAsync($"{employeeDetails.Id}".PadRight(10) + $"{employeeDetails.Name}".PadRight(20) + $"{employeeDetails.Role}");

                await Console.Out.WriteAsync("Please enter the role: ");
                string role = Console.ReadLine();
                if (employeeDetails.Role == role)
                {
                    await Console.Out.WriteLineAsync($"Roles is already {employeeDetails.Role}");
                }
                else
                {
                    employeeDetails.Role = role;

                    var results = await employeeLoginBL.changeRole(employeeDetails);
                    if (results != null)
                    {
                        await Console.Out.WriteLineAsync("Role Updated Successfully");
                    }
                    else
                    {
                        await Console.Out.WriteLineAsync("Error");
                    }
                }
                await Console.Out.WriteLineAsync();
            }
            catch(UserNotFoundException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }

    }
}
