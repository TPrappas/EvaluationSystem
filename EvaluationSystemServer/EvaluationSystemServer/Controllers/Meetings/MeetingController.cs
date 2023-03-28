using EvaluationSystemServer.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the Meetings
        /// </summary>
        protected IQueryable<MeetingEntity> MeetingsQuery => mContext.Meetings.Include(x => x.Organizer);

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
        public Task<ActionResult<MeetingResponseModel>> CreateMeetingAsync([FromBody] CreateMeetingRequestModel model)
            => ControllerHelpers.PostAsync<MeetingEntity, MeetingResponseModel>(
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
        public Task<ActionResult<IEnumerable<EmbeddedMeetingResponseModel>>> GetMeetingsAsync([FromQuery] MeetingArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<MeetingEntity, bool>>>();

            // If Search is not null...
            if (!string.IsNullOrEmpty(args.Search))
                // Add to filters
                filters.Add(x => x.Title.Contains(args.Search));

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // If the included Orgnizers is not null...
            if (args.IncludeOrganizer is not null)
                // Add to filters
                filters.Add(x => args.IncludeOrganizer.Contains(x.OrganizerId));

            // If the excluded Organizers is not null...
            if (args.ExcludeOrganizer is not null)
                // Add to filters
                filters.Add(x => !args.ExcludeOrganizer.Contains(x.OrganizerId));

            // If the After Date is not null...
            if (args.AfterDate is not null)
                // Add to filters
                filters.Add(x => x.MeetingDate >= args.AfterDate);

            // If the Before Date is not null...
            if (args.BeforeDate is not null)
                // Add to filters
                filters.Add(x => x.MeetingDate <= args.BeforeDate);

            // If the min Duration is not null...
            if (args.MinDuration is not null)
                // Add to filters
                filters.Add(x => args.MinDuration >= x.Duration);

            // If the max Duration is not null...
            if (args.MaxDuration is not null)
                // Add to filters
                filters.Add(x => args.MaxDuration <= x.Duration);

            // Gets the response models for each certificate entity
            return ControllerHelpers.GetAllAsync<MeetingEntity, EmbeddedMeetingResponseModel>(
                MeetingsQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the meeting with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="meetingId">The meeting's id</param>
        /// Get api/meetings/{meetingsId} == api/meetings/1
        [HttpGet]
        [Route(Routes.MeetingRoute)]
        public Task<ActionResult<EmbeddedMeetingResponseModel>> GetMeetingAsync([FromRoute] int meetingId)
        {
            // The needed expression for the filter
            Expression<Func<MeetingEntity, bool>> filter = x => x.Id == meetingId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<MeetingEntity, EmbeddedMeetingResponseModel>(
                MeetingsQuery,
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
        public Task<ActionResult<MeetingResponseModel>> UpdateMeetingAsync([FromRoute] int meetingId, [FromBody] UpdateMeetingRequestModel model)
        {
            return ControllerHelpers.PutAsync<UpdateMeetingRequestModel, MeetingEntity, MeetingResponseModel>(
                mContext,
                MeetingsQuery,
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
        public Task<ActionResult<MeetingResponseModel>> DeleteMeetingAsync([FromRoute] int meetingId)
        {
            return ControllerHelpers.DeleteAsync<MeetingEntity, MeetingResponseModel>(
                mContext,
                MeetingsQuery,
                DI.GetMapper,
                x => x.Id == meetingId);
        }

        #endregion
    }
}
