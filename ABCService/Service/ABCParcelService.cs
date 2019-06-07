using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABCService.IService;
using ABCService.Service;
using ABCIntegration.DAO;
using ABCIntegration;



namespace ABCService.Service
{
    public class ABCParcelService : ABCParcelIService
    {
        private ABCParcelDAO _parcelDAO;
        public ABCParcelService()
        {
            _parcelDAO = new ABCParcelDAO();
        }

        //To Implement
        //Method name: GetParcels
        //Method type: IList
        //Parameter name:
        //Parameter type:
        //Return type: Ilist
        //Submission: Assignment 1
        public IList<Parcel> GetParcels()
        {
            return _parcelDAO.GetParcels();
        }


        //To Implement
        //Method name: CreateParcel
        //Return Type: Void
        //Parameter type: Parcel
        //Parsmenter Name: New_Parcel_Record
        //Submission: Assignment 2
        //Date: 11-03-2015

        public void CreateParcel(Parcel New_Parcel_Record)
        {
            _parcelDAO.CreateParcel(New_Parcel_Record);
        }

        //To Implement
        //Method name: GetBranches
        //Method type: IList
        //Parameter name:
        //Parameter type:
        //Return type: Ilist
        //Submission: Required for Assignment 2
        //Date: 11-03-2015
        public IList<Branch> GetBranches()
        {
            return _parcelDAO.GetBranches();
        }


        //To Implement
        //Method name: GetParcel
        //Parameter name: Parcel_Id
        //Parameter type: Int
        //Return type: Parcel
        //Submission: Required for Assignment 2
        //Date: 12-03-2015
        public Parcel GetParcel(int Parcel_Id)
        {
            return _parcelDAO.GetParcel(Parcel_Id);
        }


        //To Implement
        //Method name: EditParcel
        //Parameter name: Parcel_Record
        //Parameter type: Parcel
        //Return type: Void
        //Submission: Required for Assignment 2
        //Date: 12-03-2015

        public void EditParcel(Parcel Parcel_Record)
        {
            _parcelDAO.EditParcel(Parcel_Record);
        }



        //To Implement
        //Method name: DeleteParcel
        //Parameter name: Recording
        //Parameter type: Parcel
        //Return type: Void
        //Submission: Required for Assignment 2
        //Date: 12-03-2015
        public void DeleteParcel(Parcel Recording)
        {
            _parcelDAO.DeleteParcel(Recording);
        }


        //To Implement
        //Method name: AddParcelTrackingId
        //Parameter name: Parcel_Record
        //Parameter type: Parcel
        //Return type: Void
        //Submission: Required for Assignment 3
        //Date: 20-04-201
        public void AddParcelTrackingId(Parcel Parcel_Record)
        {
            _parcelDAO.AddParcelTrackingId(Parcel_Record);
        }

        //To Implement
        //Method name: CreateBranch
        //Return Type: Void
        //Parameter type: Branch
        //Parsmenter Name: New_Branch_Record
        //Submission: Assignment 3
        //Date: 21-04-2015
        public void CreateBranch(Branch New_Branch_Record)
        {
            _parcelDAO.CreateBranch(New_Branch_Record);
        }

        //To Implement
        //Method name: CreateUserBranch
        //Return Type: Void
        //Parameter type: Branch
        //Parsmenter Name: New_UserBranch_Record
        //Submission: Assignment 3
        //Date: 21-04-2015
        public void CreateUserBranch(UserBranch New_UserBranch_Record)
        {
            _parcelDAO.CreateUserBranch(New_UserBranch_Record);
        }

        //To Implement
        //Method name: GetUserBranchCode
        //Parameter name: UserName
        //Parameter type: string
        //Return type: UserBranch
        //Submission: Required for Assignment 3
        //Date: 21-04-2015
        public UserBranch GetUserBranchCode(string UserName)
        {
            return _parcelDAO.GetUserBranchCode(UserName);
        }


        //To Implement
        //Method name: LogParcelMovement
        //Return Type: Void
        //Parameter type: Parcel_Tracking_Log
        //Parsmenter Name: New_Parcel_Movement_Record
        //Submission: Assignment 3
        //Date: 21-04-2015
        public void LogParcelMovement(Parcel_Tracking_Log New_Parcel_Movement_Record)
        {
            _parcelDAO.LogParcelMovement(New_Parcel_Movement_Record);
        }


        //To Implement
        //Method name: GetBranch
        //Parameter name: Branch_Code
        //Parameter type: String
        //Return type: Branch
        //Submission: Required for Assignment 3
        //Date: 23-04-2015
        public Branch GetBranch(string Branch_Code)
        {
            return _parcelDAO.GetBranch(Branch_Code);
        }


        //To Implement
        //Method name: GetParcelTrackingLog
        //Parameter name: Tracking_Id
        //Parameter type: String
        //Return type: IList
        //Submission: Required for Assignment 3
        //Date: 23-04-2015
        public IList<Parcel_Tracking_Log> GetParcelTrackingLog(string Tracking_Id)
        {
            return _parcelDAO.GetParcelTrackingLog(Tracking_Id);
        }


        //To Implement
        //Method name: GetParcels
        //Parameter name: Username
        //Parameter type: string
        //Return type: Ilist
        //Submission: Assignment 4
        public IList<Parcel> GetUserParcels(string Username)
        {
            return _parcelDAO.GetUserParcels(Username);
        }




    }
}
