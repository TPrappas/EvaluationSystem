using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class MeetingController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public MeetingController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new meetings
        /// </summary>
        /// Post api/meetings
        [HttpPost]
        [Route(Routes.MeetingsRoute)]
        public Task<ActionResult<MeetingResponseModel>> CreateMeetingAsync([FromBody] MeetingRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.Meetings,
                MeetingEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the meetings from the database
        /// </summary>
        /// Get api/meetings
        [HttpGet]
        [Route(Routes.MeetingsRoute)]
        public Task<ActionResult<IEnumerable<MeetingResponseModel>>> GetMeetingsAsync() =>
            // Gets the response models for each certificate entity
            ControllerHelpers.GetAllAsync<MeetingEntity, MeetingResponseModel>(
                mContext.Meetings,
                x => true);

        /// <summary>
        /// Gets the meeting with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="meetingId">The meeting's id</param>
        /// Get api/meetings/{meetingsId} == api/meetings/1
        [HttpGet]
        [Route(Routes.MeetingRoute)]
        public Task<ActionResult<MeetingResponseModel>> GetMeetingAsync([FromRoute] int meetingId)
        {
            // The needed expression for the filter
            Expression<Func<MeetingEntity, bool>> filter = x => x.Id == meetingId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<MeetingEntity, MeetingResponseModel>(
                mContext.Meetings,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the meeting with the specified id
        /// </summary>
        /// <param name="meetingId">The meeting's id</param>
        /// <param name="model">The meeting request model</param>
        /// Put /api/meetings/{meetingId}
        [HttpPut]
        [Route(Routes.MeetingRoute)]
        public Task<ActionResult<MeetingResponseModel>> UpdateMeetingAsync([FromRoute] int meetingId, [FromBody] MeetingRequestModel model)
        {
            return ControllerHelpers.PutAsync<MeetingRequestModel, MeetingEntity, MeetingResponseModel>(
                mContext,
                mContext.Meetings,
                model,
                x => x.Id == meetingId);
        }

        /// <summary>
        /// Deletes the certificate with the specified id if exists from the database
        /// </summary>
        /// <param name="meetingId">The meeting's id</param>
        /// Delete /api/meetings/{meetingId}
        [HttpDelete]
        [Route(Routes.MeetingRoute)]
        public Task<ActionResult<MeetingResponseModel>> DeleteMeetingAsync(int meetingId)
        {
            return ControllerHelpers.DeleteAsync<MeetingEntity, MeetingResponseModel>(
                mContext,
                mContext.Meetings,
                DI.GetMapper,
                x => x.Id == meetingId);
        }

        #endregion
    }
}
