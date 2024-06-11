using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Generate random unique names for the patients
            var random = new Random();
            int totalPatients = 1000;
            var firstNames = new[]
            {
                "John", "Jane", "Alex", "Emily", "Chris", "Katie", "Mike", "Laura",
                "Sarah", "David", "Robert", "Linda", "James", "Barbara", "Joseph", "Elizabeth",
                "Thomas", "Jennifer", "Charles", "Patricia", "Daniel", "Mary", "Matthew", "Sandra",
                "Mark", "Ashley", "Steven", "Kimberly", "Paul", "Deborah", "Andrew", "Jessica",
                "Joshua", "Donna", "Kenneth", "Michelle", "Kevin", "Carol", "Brian", "Amanda",
                "George", "Melissa", "Edward", "Stephanie", "Ronald", "Rebecca", "Timothy", "Sharon",
                "Jason", "Laura", "Jeffrey", "Cynthia", "Ryan", "Kathleen", "Gary", "Helen",
                "Nicholas", "Amy", "Eric", "Angela", "Jonathan", "Shirley", "Stephen", "Brenda",
                "Larry", "Emma", "Scott", "Anna", "Frank", "Nancy", "Justin", "Lisa",
                "Brandon", "Dorothy", "Raymond", "Margaret", "Gregory", "Betty", "Samuel", "Ruth",
                "Benjamin", "Diane", "Patrick", "Alice", "Jack", "Julie", "Dennis", "Heather",
                "Jerry", "Martha", "Tyler", "Christine", "Aaron", "Marie", "Henry", "Janet",
                "Douglas", "Frances", "Peter", "Gloria", "Jose", "Ann", "Adam", "Teresa",
                "Nathan", "Doris", "Zachary", "Joyce", "Walter", "Evelyn", "Harold", "Jean"
            };
            var lastNames = new[]
            {
                "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia",
                "Rodriguez", "Wilson", "Martinez", "Anderson", "Taylor", "Thomas", "Hernandez", "Moore",
                "Martin", "Jackson", "Thompson", "White", "Lopez", "Lee", "Gonzalez", "Harris",
                "Clark", "Lewis", "Robinson", "Walker", "Perez", "Hall", "Young", "Allen",
                "Sanchez", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson",
                "Hill", "Ramirez", "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans",
                "Turner", "Torres", "Parker", "Collins", "Edwards", "Stewart", "Flores", "Morris",
                "Nguyen", "Murphy", "Rivera", "Cook", "Rogers", "Morgan", "Peterson", "Cooper",
                "Reed", "Bailey", "Bell", "Gomez", "Kelly", "Howard", "Ward", "Cox",
                "Diaz", "Richardson", "Wood", "Watson", "Brooks", "Bennett", "Gray", "James",
                "Reyes", "Cruz", "Hughes", "Price", "Myers", "Long", "Foster", "Sanders",
                "Ross", "Morales", "Powell", "Sullivan", "Russell", "Ortiz", "Jenkins", "Gutierrez",
                "Perry", "Butler", "Barnes", "Fisher"
            };

            var usedNames = new HashSet<string>();

            for (int i = 1; i <= totalPatients; i++)
            {
                string uniqueName;
                do
                {
                    var firstName = firstNames[random.Next(firstNames.Length)];
                    var lastName = lastNames[random.Next(lastNames.Length)];
                    uniqueName = $"{firstName} {lastName}";
                } while (usedNames.Contains(uniqueName));

                usedNames.Add(uniqueName);

                migrationBuilder.UpdateData(
                    table: "Patients",
                    keyColumn: "Id",
                    keyValue: i,
                    column: "Name",
                    value: uniqueName
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 1; i <= 1000; i++)
            {
                migrationBuilder.UpdateData(
                    table: "Patients",
                    keyColumn: "Id",
                    keyValue: i,
                    column: "Name",
                    value: $"Patient {i}"
                );
            }
        }
    }
}
