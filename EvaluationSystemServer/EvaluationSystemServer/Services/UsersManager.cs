using Microsoft.EntityFrameworkCore;

namespace EvaluationSystemServer
{
    public class UsersManager
    {
        #region Public Methods

        public async Task<UserEntity> AddUserAsync(UserRequestModel model)
        {
            // Get the database context
            var dbContext = DI.GetDbContext;

            // Create the user
            var user = DI.GetMapper.Map<UserEntity>(model);

            // Add it to the database
            dbContext.Users.Add(user);

            // Save the changes to get a user id
            await dbContext.SaveChangesAsync();

            // If there are user certificates...
            if (model.Certificates is not null)
            {
                // For every certificate id...
                foreach(var id in model.Certificates)
                    // Add the certificate
                    dbContext.UserCertificates.Add(new UserCertificateEntity() { CertificateId = id, UserId = user.Id });

                // Save the changes
                await dbContext.SaveChangesAsync();
            }

            // If there are user skills...
            if (model.Skills is not null) 
            {
                // For every skill id...
                foreach (var id in model.Skills)
                    // Add the skill
                    dbContext.UserSkills.Add(new UserSkillEntity() { SkillId = id, UserId = user.Id });

                // Save the changes
                await dbContext.SaveChangesAsync();
            }

            // If there are participant meetings...
            if (model.ParticipantMeetings is not null) 
            {
                // For every meeting id...
                foreach (var id in model.ParticipantMeetings)
                    // Add the meeting
                    dbContext.ParticipantMeetings.Add(new ParticipantMeetingEntity() { MeetingId = id, ParticipantId = user.Id });

                // Save the changes
                await dbContext.SaveChangesAsync();
            }

            // Return the user
            return user;
        }

        public async Task<UserEntity> UpdateUserAsync(int id, UserRequestModel model)
        {
            // Get the database context
            var dbContext = DI.GetDbContext;

            // Get the user
            var user = await dbContext.Users.FirstAsync(x => x.Id == id);

            // Update the values that can be updated using the AutoMapper
            DI.GetMapper.Map(model, user);

            // Save the changes
            await dbContext.SaveChangesAsync();

            // If there are user certificates...
            if (model.Certificates is not null)
            {
                // Get the existing user certificates
                var existingUserCertificates = await dbContext.UserCertificates.Where(x => x.UserId == user.Id).ToListAsync();    

                // For every existing user certificate...
                foreach(var existingUserCeriticate in existingUserCertificates)
                {
                    // If it is not contained in the requested ids...
                    if (model.Certificates.Any(x => x == existingUserCeriticate.CertificateId))
                        // Remove it
                        dbContext.UserCertificates.Remove(existingUserCeriticate);
                }

                // For every certificate id...
                foreach(var certificateId in model.Certificates)
                {
                    // If there isn't a user certificate with that id...
                    if (!existingUserCertificates.Any(x => x.CertificateId == certificateId))
                        // Add the certificate
                        dbContext.UserCertificates.Add(new UserCertificateEntity() { CertificateId = id, UserId = user.Id });
                }

                // Save the changes
                await dbContext.SaveChangesAsync();
            }

            // If there are user skills...
            if (model.Skills is not null) 
            { 
                // Get the existing use skills 
                var existingUserSkills = await dbContext.UserSkills.Where(x => x.UserId == user.Id).ToListAsync();

                // For every existing user skill...
                foreach(var existingUserSkill in existingUserSkills)
                {
                    // If it is not contained in the requested ids...
                    if (model.Skills.Any(x => x == existingUserSkill.SkillId))
                        // Remove it
                        dbContext.UserSkills.Remove(existingUserSkill);
                }

                // For every skill id...
                foreach(var skillId in model.Skills)
                {
                    // If there isn't a user skill with that id...
                    if (!existingUserSkills.Any(x => x.SkillId == skillId))
                        // Add the skill
                        dbContext.UserSkills.Add(new UserSkillEntity() { SkillId = skillId, UserId= user.Id });
                }
            }

            // if there are participant meetings
            if (model.ParticipantMeetings is not null)
            {
                // Get the existing participant meetings
                var existingParticipantMeetings = await dbContext.ParticipantMeetings.Where(x => x.ParticipantId == user.Id).ToListAsync();

                // For every existing participant meeting...
                foreach(var existingParticipantMetting in existingParticipantMeetings) 
                { 
                    // If it is not contained in the requested ids...
                    if (model.ParticipantMeetings.Any(x => x == existingParticipantMetting.MeetingId))
                        // Remove it
                        dbContext.ParticipantMeetings.Remove(existingParticipantMetting);
                }

                // For every meeting id...
                foreach (var meetingId in model.ParticipantMeetings)
                {
                    // If there isn't a participant meeting with that id...
                    if (!existingParticipantMeetings.Any(x => x.MeetingId == meetingId))
                        // Add the meeting
                        dbContext.ParticipantMeetings.Add(new ParticipantMeetingEntity() { MeetingId = meetingId, ParticipantId = user.Id });
                }
            }

            // Return the user
            return user;
        }

        #endregion
    }
}
