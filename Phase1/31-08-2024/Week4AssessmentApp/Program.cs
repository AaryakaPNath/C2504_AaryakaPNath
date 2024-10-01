// Problem Statement: Patient Vital Signs Tracker
// - Define a class: `VitalSigns` with the following properties:
// - `PatientID` (integer)
// - `HeartRate` (integer, beats per minute)
// - `BloodPressure` (string, systolic/diastolic)
// - `Temperature` (double, in Celsius)
// - Tasks:
// 1. Data Collection:
// - Read N `vitalSigns` from the keyboard.
// 2. Find Patient with Lowest Heart Rate:
// - Display the patient with the lowest heart rate.
// Solve in time complexity of O(N).
// Dont use built-in C# sorting or LINQ.
// 3. Find Second Highest Temperature:
// - Display the patient with the second highest temperature.
// Solve in time complexity of O(N).
// Dont use built-in C# sorting or LINQ.
// 4. Sort by Blood Pressure (systolic):
// - Implement and call your own sorting algorithm based on the systolic value of blood pressure.
// Dont use built-in C# sorting or LINQ.


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using log4net;

namespace Week4AssessmentApp
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }

    public class VitalSigns
    {
        public int PatientID { get; set; }
        public int HeartRate { get; set; }
        public string BloodPressure { get; set; }
        public double Temperature { get; set; }

        public override string ToString()
        {
            return $"[PatientID: {PatientID}, HeartRate: {HeartRate}, BloodPressure: {BloodPressure}, Temperature: {Temperature}]";
        }
    }

    public class VitalSignsService
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Week4AssessmentDb; Integrated Security = True;";

        public static void Read(VitalSigns[] vitalSignsArray)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT PatientID, HeartRate, BloodPressure, Temperature FROM VitalSigns";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    for (int i = 0; i < vitalSignsArray.Length; i++)
                    {
                        if (!reader.Read())
                        {
                            throw new ServerException("[0101] Server Error: Not enough data in the database.");
                        }
                        vitalSignsArray[i] = new VitalSigns
                        {
                            PatientID = (int)reader["PatientID"],
                            HeartRate = (int)reader["HeartRate"],
                            BloodPressure = reader["BloodPressure"].ToString(),
                            Temperature = (double)reader["Temperature"]
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ServerException($"[0102] SQL Error: {ex.Message}");
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServerException($"[0103] General Error: {ex.Message}");
            }
        }

        public static VitalSigns FindPatientWithLowestHeartRate(VitalSigns[] vitalSignsArray)
        {
            var minHeartRatePatient = vitalSignsArray[0];
            foreach (var patient in vitalSignsArray)
            {
                if (patient.HeartRate < minHeartRatePatient.HeartRate)
                {
                    minHeartRatePatient = patient;
                }
            }
            return minHeartRatePatient;
        }

        public static VitalSigns FindPatientWithSecondHighestTemperature(VitalSigns[] vitalSignsArray)
        {
            double highestTemperature = double.MinValue;
            double secondHighestTemperature = double.MinValue;

            foreach (var patient in vitalSignsArray)
            {
                if (patient.Temperature > highestTemperature)
                {
                    secondHighestTemperature = highestTemperature;
                    highestTemperature = patient.Temperature;
                }
                else if (patient.Temperature > secondHighestTemperature && patient.Temperature < highestTemperature)
                {
                    secondHighestTemperature = patient.Temperature;
                }
            }

            foreach (var patient in vitalSignsArray)
            {
                if (patient.Temperature == secondHighestTemperature)
                {
                    return patient;
                }
            }

            return null;
        }

        public static void SelectionSortBySystolicBloodPressure(VitalSigns[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    string[] bp1 = array[j].BloodPressure.Split('/');
                    string[] bp2 = array[minIndex].BloodPressure.Split('/');
                    int systolic1 = int.Parse(bp1[0]);
                    int systolic2 = int.Parse(bp2[0]);

                    if (systolic1 < systolic2)
                    {
                        minIndex = j;
                    }
                }
                var temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }

    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            VitalSigns[] vitalSignsArray = new VitalSigns[3];

            try
            {
                VitalSignsService.Read(vitalSignsArray);
            }
            catch (ServerException ex)
            {
                log.Error($"{ex.Message}");
                return;
            }

            var minHeartRatePatient = VitalSignsService.FindPatientWithLowestHeartRate(vitalSignsArray);
            log.Info($"Patient with lowest heart rate: {minHeartRatePatient}");

            var secondHighestTempPatient = VitalSignsService.FindPatientWithSecondHighestTemperature(vitalSignsArray);
            if (secondHighestTempPatient != null)
            {
                log.Info($"Patient with second highest temperature: {secondHighestTempPatient}");
            }
            else
            {
                log.Info("No second highest temperature found.");
            }

            VitalSignsService.SelectionSortBySystolicBloodPressure(vitalSignsArray);

            log.Info("Patients sorted by systolic blood pressure:");
            foreach (var patient in vitalSignsArray)
            {
                log.Info(patient);
            }
        }
    }
}