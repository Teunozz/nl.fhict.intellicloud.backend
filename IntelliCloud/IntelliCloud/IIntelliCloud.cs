﻿using nl.fhict.IntelliCloud.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IntelliCloud
{
    [ServiceContract]
    public interface IIntelliCloud
    {
        /// <summary>
        /// This method is used to ask a question to a employee
        /// </summary>
        /// <param name="source">the name of the source as the source is known in the database</param>
        /// <param name="reference">the reference needed by the plugin to send the answers back</param>
        /// <param name="question">the question itself</param>
        /// <returns>Returns wether the question upload was succesfull of failed</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "AskQuestion", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        Boolean AskQuestion(String source, String reference, String question);

        /// <summary>
        /// This method is used to send a answer directly back to the asker, in this case there won't be any reviewing
        /// </summary>
        /// <param name="questionId">The questionId of the question that this answer answers</param>
        /// <param name="answer">The answer itself</param>
        /// <param name="answererId">The Id of the employee who answerd the question</param>
        /// <returns>Returns wether the send was succesfull of failed</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "SendAnswer", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        Boolean SendAnswer(String questionId, String answer, String answererId);

        /// <summary>
        /// This method return the question availible to this employee
        /// </summary>
        /// <param name="employeeId">The employeeId of the employee who requests the questions</param>
        /// <returns>Returns the questions availible to this employee</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "GetQuestions", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        List<Question> GetQuestions(String employeeId);

        /// <summary>
        /// This method is used to accept answers
        /// </summary>
        /// <param name="feedback">Use this parameter if the answer is correct but still can use some tweaking</param>
        /// <param name="answerId">The Id of the answer you want to accept</param>
        /// <param name="questionId">The Id of the question where this answer is accepted for</param>
        /// <returns>Returns wether the accept succeded of failed</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "AcceptAnswer", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        Boolean AcceptAnswer(String feedback, String answerId, String questionId);

        /// <summary>
        /// This method is used to decline answers
        /// </summary>
        /// <param name="feedback">Use this parameter to fill in wath is missing for this answer to be correct</param>
        /// <param name="answerId">The Id of the answer you want to decline</param>
        /// <param name="questionId">The Id of the question where this answer is declined for</param>
        /// <returns>Returns wether the decline succeded of failed</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "DeclineAnswer", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        Boolean DeclineAnswer(String feedback, String answerId, String questionId);

        /// <summary>
        /// This method is used to put a answer up for review, this way colleagues can review the answer
        /// </summary>
        /// <param name="answer">The answer you want to be reviewed</param>
        /// <param name="questionId">The id of the question this answer is the answer to</param>
        /// <param name="answererId">The id of the employee who answered the question</param>
        /// <returns>returns wether the answer was recieved by the server</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "SendAnswerForReview", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        Boolean SendAnswerForReview(String answer, String questionId, String answererId);

        /// <summary>
        /// This method is used to send a review for a specific answer
        /// </summary>
        /// <param name="reviewerId">The Id of the employee who wrote the review</param>
        /// <param name="answerId">The Id of the answer this review is written for</param>
        /// <param name="review">The review text itself</param>
        /// <returns>Return wether the review was recieved by the server</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "SendReviewForAnswer", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        Boolean SendReviewForAnswer(String reviewerId, String answerId, String review);

        /// <summary>
        /// This method is used to get all the Reviews written for a specific answer
        /// </summary>
        /// <param name="answerId">The Id of the answer you want to get the reviews for</param>
        /// <returns>Return a list containing all the reviews for this specified answer</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "GetReviewsForAnswer", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        List<Review> GetReviewsForAnswer(String answerId);

        /// <summary>
        /// This method is used to get all the answer you can review
        /// </summary>
        /// <param name="employeeId">The Id of the employee who want to review answers</param>
        /// <returns>Returns a list of all the answers that are up for review for this employee</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", 
            UriTemplate = "GetAnswersUpForReview", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        List<Answer> GetAnswersUpForReview(String employeeId);

    }
}
