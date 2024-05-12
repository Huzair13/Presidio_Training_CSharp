using RequestTrackerBL;
using RequestTrackerLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApp
{
    public class UserFrontend : IFrontend
    {
        private static Employee LoggedInEmployee;

        public UserFrontend(Employee loggedInEmployee)
        {
            LoggedInEmployee = loggedInEmployee;
        }
        public async Task DisplayMenu()
        {
            // Menu loop
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("User Menu:");
                Console.WriteLine("1. Raise a Request");
                Console.WriteLine("2. View Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. Log Out");
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        await GetRequestRaiseDetails();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "2":
                        await ViewRequestsStatus();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "3":
                        await ViewSolutions();
                        await Console.Out.WriteLineAsync();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4");
                        break;
                }
            }
        }

        //1) GET REQUEST DETAILS
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
                Console.WriteLine($"Request Raised Successfully and the Request Number is {result.RequestNumber}");
            }
            await Console.Out.WriteLineAsync();
        }

        //2) VIEW REQUEST STATUS
        private async Task ViewRequestsStatus()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            var requests = await requestRaiseBL.GetRequestsByEmployeeIDAsync(LoggedInEmployee.Id);

            Console.WriteLine("All Requests and its Status Raised By You");
            Console.WriteLine("Request ID".PadRight(15) + "Request".PadRight(30) + "Request Status".PadRight(20));
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            foreach (var request in requests)
            {
                Console.WriteLine($"{request.RequestNumber}".PadRight(15) + $"{request.RequestMessage}".PadRight(30) + $"{request.RequestStatus}".PadRight(20));
            }
            await Console.Out.WriteLineAsync();
        }

        //3) VIEW SOLUTIONS
        private async Task ViewSolutions()
        {
            RequestRaiseBL requestRaiseBL = new RequestRaiseBL();
            var requests = await requestRaiseBL.GetRequestsByEmployeeIDAsync(LoggedInEmployee.Id);

            await Console.Out.WriteLineAsync("All Closed Requests Raised By You");
            await Console.Out.WriteLineAsync("Request ID".PadRight(15) + "Request".PadRight(30));
            await Console.Out.WriteLineAsync("--------------------------------------------------------------");

            foreach (var request in requests)
            {
                if (request.RequestStatus == "Closed")
                {
                    Console.WriteLine($"{request.RequestNumber}".PadRight(15) + $"{request.RequestMessage}".PadRight(30));
                }
            }

            await Console.Out.WriteAsync("Please Enter the Request ID to view the Request Solution for the particular closed request : ");

            int requestID = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync();
            RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
            RequestSolution solution = await requestSolutionBL.GetSolutionByRequestId(requestID);
            await Console.Out.WriteLineAsync("Solution ID".PadRight(15) + "Solution Description".PadRight(30) + "Solution SolvedBy".PadRight(20) + "Solution Solved Date".PadRight(30) + "Solution IsSolved".PadRight(20) + "Request Raiser Comments");
            await Console.Out.WriteLineAsync($"{solution.SolutionId}".PadRight(15) + $"{solution.SolutionDescription}".PadRight(30) + $"{solution.SolvedBy}".PadRight(20) + $"{solution.SolvedDate}".PadRight(30) + $"{solution.IsSolved}".PadRight(20) + $"{solution?.RequestRaiserComment ?? "No Comments"}");
            await Console.Out.WriteLineAsync();
            await userMenuForRequestResponseAndFeedback(requestID, solution);
        }

        //3) VIEW SOLUTION MENU
        public async Task userMenuForRequestResponseAndFeedback(int requestID, RequestSolution solution)
        {
            bool exit = false;
            while (!exit)
            {
                await Console.Out.WriteLineAsync();
                await Console.Out.WriteLineAsync($"Operation on the Request ID : {requestID}");
                await Console.Out.WriteLineAsync("1. Give Feedback");
                await Console.Out.WriteLineAsync("2. Respond to the Solution");
                await Console.Out.WriteLineAsync("3. Exit to the Main Menu");
                await Console.Out.WriteLineAsync("Enter your choice (1-3): ");

                string choice = Console.ReadLine();

                Console.WriteLine();
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
                        exit= true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3");
                        await Console.Out.WriteLineAsync();
                        break;
                }
            }
        }

        //3 A)GET FEEDBACK DETAILS
        private async Task GetFeedbackDetails(RequestSolution solution)
        {
            int solutionId = solution.SolutionId;

            await Console.Out.WriteAsync($"Please enter the Remarks for the Solution ID {solutionId} : ");
            string remarks = Console.ReadLine();

            await Console.Out.WriteAsync("Please enter the rating : ");
            float ratings = float.Parse(Console.ReadLine());

            int feedbackBy = LoggedInEmployee.Id;
            DateTime feedbackDate = DateTime.Now;

            await AddFeedbackToSolution(solutionId, remarks, ratings, feedbackBy, feedbackDate);

        }

        //3 A)ADD FEEDBACK TO THE SOLUTION
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

        //3 B) RESPOND TO SOLUTION
        private async Task RespondToSolution(int requestID, RequestSolution solution)
        {
            await Console.Out.WriteAsync($"Please enter the your Response to the Solution ID {solution.SolutionId} : ");
            string response = Console.ReadLine();

            solution.RequestRaiserComment= response;

            RequestSolutionBL requestSolutionBL = new RequestSolutionBL();
            requestSolutionBL.AddCommentsToTheSolutions(requestID,solution.SolutionId, response);
        }

        


       

    }
}
