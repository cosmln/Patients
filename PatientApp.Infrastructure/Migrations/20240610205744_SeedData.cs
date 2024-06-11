using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var random = new Random();
            int totalPatients = 1000;
            int totalAppointments = 3000;

            for (int i = 1; i <= totalPatients; i++)
            {
                migrationBuilder.InsertData(
                    table: "Patients",
                    columns: new[] { "Id", "Name" },
                    values: new object[] { i, $"Patient {i}" }
                );
            }

            var meetingTypes = new[]
            {
                new { Id = 1, Description = "Consultation" },
                new { Id = 2, Description = "Follow-up" },
                new { Id = 3, Description = "Emergency" }
            };

            foreach (var meetingType in meetingTypes)
            {
                migrationBuilder.InsertData(
                    table: "MeetingTypes",
                    columns: new[] { "Id", "Description" },
                    values: new object[] { meetingType.Id, meetingType.Description }
                );
            }

            for (int i = 1; i <= totalAppointments; i++)
            {
                migrationBuilder.InsertData(
                    table: "Appointments",
                    columns: new[] { "Id", "Date", "MeetingTypeId", "PatientId" },
                    values: new object[]
                    {
                        i,
                        DateTime.UtcNow.AddDays(random.Next(1, 365)),
                        random.Next(1, 4), 
                        random.Next(1, totalPatients + 1) 
                    }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Appointments");
            migrationBuilder.Sql("DELETE FROM MeetingTypes");
            migrationBuilder.Sql("DELETE FROM Patients");
        }
    }
}
