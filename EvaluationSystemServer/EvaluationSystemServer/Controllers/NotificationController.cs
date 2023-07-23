using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EvaluationSystemServer
{
    public class NotificationController : Controller
    {
        #region Private Members

        /// <summary>
        /// The DB context
        /// </summary>
        private readonly EvaluationSystemDBContext mContext;

        #endregion

        #region Protected Properties

        /// <summary>
        /// The query used for retrieving the users 
        /// </summary>
        protected IQueryable<NotificationEntity> NotificationsQuery => mContext.Notifications.Include(x => x.User);

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public NotificationController(EvaluationSystemDBContext context)
        {
            mContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new notification
        /// </summary>
        /// Post home/notifications
        [HttpPost]
        [Route(Routes.NotificationsRoute)]
        public Task<ActionResult<NotificationResponseModel>> CreateNotificationAsync([FromBody] NotificationRequestModel model)
            => ControllerHelpers.PostAsync(
                mContext,
                mContext.Notifications,
                NotificationEntity.FromRequestModel(model),
                x => x.ToResponseModel());

        /// <summary>
        /// Gets all the notifications from the database
        /// </summary>
        /// Get home/notifications
        [HttpGet]
        [Route(Routes.NotificationsRoute)]
        public Task<ActionResult<IEnumerable<NotificationResponseModel>>> GetNotificationsAsync([FromQuery] NotificationArgs args)
        {
            // The list of the filters
            var filters = new List<Expression<Func<NotificationEntity, bool>>>();

            // If the After Date Created is not null...
            if (args.AfterDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated >= args.AfterDateCreated);

            // If the Before Date Created is not null...
            if (args.BeforeDateCreated is not null)
                // Add to filters
                filters.Add(x => x.DateCreated <= args.BeforeDateCreated);

            // Gets the response models for each user entity
            return ControllerHelpers.GetAllAsync<NotificationEntity, NotificationResponseModel>(
                NotificationsQuery,
                args,
                filters);
        }

        /// <summary>
        /// Gets the notification with the specified id from the database if exists...
        /// Else returns not found
        /// </summary>
        /// <param name="notificationId">The notification's id</param>
        /// Get home/notifications/{notificationId} == home/notifications/2
        [HttpGet]
        [Route(Routes.NotificationRoute)]
        public Task<ActionResult<NotificationResponseModel>> GetNotificationAsync([FromRoute] int notificationId)
        {
            // The needed expression for the filter
            Expression<Func<NotificationEntity, bool>> filter = x => x.Id == notificationId;

            // Gets the response model 
            return ControllerHelpers.GetAsync<NotificationEntity, NotificationResponseModel>(
                NotificationsQuery,
                DI.GetMapper,
                filter);
        }

        /// <summary>
        /// Updates the notification with the specified id
        /// </summary>
        /// <param name="notificationId">The notification's id</param>
        /// <param name="model">The notification request model</param>
        /// Put /home/notifications/{notificationId}
        [HttpPut]
        [Route(Routes.NotificationRoute)]
        public Task<ActionResult<NotificationResponseModel>> UpdateNotificationAsync([FromRoute] int notificationId, [FromBody] NotificationRequestModel model)
        {
            return ControllerHelpers.PutAsync<NotificationRequestModel, NotificationEntity, NotificationResponseModel>(
                mContext,
                NotificationsQuery,
                model,
                x => x.Id == notificationId);
        }

        /// <summary>
        /// Deletes the notification with the specified id if exists from the database
        /// </summary>
        /// <param name="notificationId">The notification's id</param>
        /// Delete /home/notifications/{notificationId}
        [HttpDelete]
        [Route(Routes.NotificationRoute)]
        public Task<ActionResult<NotificationResponseModel>> DeleteNotificationAsync([FromRoute] int notificationId)
        {
            return ControllerHelpers.DeleteAsync<NotificationEntity, NotificationResponseModel>(
                mContext,
                NotificationsQuery,
                DI.GetMapper,
                x => x.Id == notificationId);
        }

        #endregion
    }
}
