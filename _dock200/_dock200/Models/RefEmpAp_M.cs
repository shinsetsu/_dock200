using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _dock200.Models
{
	public class RefEmpAp_M
	{

		public interface IRefEmpAp_M { }
		public RefEmpAp_M() { }     //Constructor
		public RefEmpAp_M(DateTime todayDate, string fN, string lN, string mI, string stAddress, string city, string zipcode, string phone, string email, string permAddress, string positionAppliedFor, string workWeekends, string workEvenings, string legallyEligibleEmp, string transportation, string convictedofFelony, string highestLevelAtended, string highestDegree, string school, string currentlyStudent, string studentCapacity, string employer, DateTime eMPDateFrom, DateTime eMPDateTo, string eMPCity, string eMPState, string eMPPhone, string eMPManager, string mayWeContact, string signature, DateTime sigDate, DateTime dateRecieved, DateTime interviewDate, string specialNotes) { TodayDate = todayDate; FN = fN; LN = lN; MI = mI; StAddress = stAddress; City = city; Zipcode = zipcode; Phone = phone; Email = email; PermAddress = permAddress; PositionAppliedFor = positionAppliedFor; WorkWeekends = workWeekends; WorkEvenings = workEvenings; LegallyEligibleEmp = legallyEligibleEmp; Transportation = transportation; ConvictedofFelony = convictedofFelony; HighestLevelAtended = highestLevelAtended; HighestDegree = highestDegree; School = school; CurrentlyStudent = currentlyStudent; StudentCapacity = studentCapacity; Employer = employer; EMPDateFrom = eMPDateFrom; EMPDateTo = eMPDateTo; EMPCity = eMPCity; EMPState = eMPState; EMPPhone = eMPPhone; EMPManager = eMPManager; MayWeContact = mayWeContact; Signature = signature; SigDate = sigDate; DateRecieved = dateRecieved; InterviewDate = interviewDate; SpecialNotes = specialNotes; }


		[Key] [DisplayName("Id}")] public int id { get; set; }

		public DateTime TodayDate { get; set; }
		public string FN { get; set; }
		public string LN { get; set; }
		public string MI { get; set; }
		public string StAddress { get; set; }
		public string City { get; set; }
		public string Zipcode { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string PermAddress { get; set; }
		public string PositionAppliedFor { get; set; }
		public string WorkWeekends { get; set; }
		public string WorkEvenings { get; set; }
		public string LegallyEligibleEmp { get; set; }
		public string Transportation { get; set; }
		public string ConvictedofFelony { get; set; }

		public string HighestLevelAtended { get; set; }
		public string HighestDegree { get; set; }
		public string School { get; set; }
		public string CurrentlyStudent { get; set; }
		public string StudentCapacity { get; set; }

		public string Employer { get; set; }
		public DateTime EMPDateFrom { get; set; }
		public DateTime EMPDateTo { get; set; }
		public string EMPCity { get; set; }
		public string EMPState { get; set; }
		public string EMPPhone { get; set; }
		public string EMPManager { get; set; }
		public string MayWeContact { get; set; }

		public string Signature { get; set; }
		public DateTime SigDate { get; set; }

		public DateTime DateRecieved { get; set; }
		public DateTime InterviewDate { get; set; }
		public string SpecialNotes { get; set; }

	}
}
