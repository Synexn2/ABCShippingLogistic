using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABCIntegration;

namespace ABCService.IService
{
    interface ABCParcelIService
    {

        //To Implement
        //Method name: GetParcels
        //Method type: IList
        //Parameter name:
        //Parameter type:
        //Return type: Ilist
        //Submission: Assignment 1
        IList<Parcel> GetParcels();


        //To Implement
        //Method name: CreateParcel
        //Return Type: Void
        //Parameter type: Parcel
        //Parsmenter Name: New_Parcel_Record
        //Submission: Assignment 2
        //Date: 11-03-2015

        void CreateParcel(Parcel New_Parcel_Record);

        //To Implement
        //Method name: GetBranches
        //Method type: IList
        //Parameter name:
        //Parameter type:
        //Return type: Ilist
        //Submission: Required for Assignment 2
        //Date: 11-03-2015
        IList<Branch> GetBranches();

        //To Implement
        //Method name: GetParcel
        //Parameter name: Parcel_Id
        //Parameter type: Int
        //Return type: Parcel
        //Submission: Required for Assignment 2
        //Date: 12-03-2015
        Parcel GetParcel(int Parcel_Id);


        //To Implement
        //Method name: EditParcel
        //Parameter name: Parcel_Record
        //Parameter type: Parcel
        //Return type: Void
        //Submission: Required for Assignment 2
        //Date: 12-03-2015

        void EditParcel(Parcel Parcel_Record);


        //To Implement
        //Method name: DeleteParcel
        //Parameter name: Recording
        //Parameter type: Parcel
        //Return type: Void
        //Submission: Required for Assignment 2
        //Date: 12-03-2015
        void DeleteParcel(Parcel Recording);

        //To Implement
        //Method name: AddParcelTrackingId
        //Parameter name: Parcel_Record
        //Parameter type: Parcel
        //Return type: Void
        //Submission: Required for Assignment 3
        //Date: 20-04-201
        void AddParcelTrackingId(Parcel Parcel_Record);

        //To Implement
        //Method name: CreateBranch
        //Return Type: Void
        //Parameter type: Branch
        //Parsmenter Name: New_Branch_Record
        //Submission: Assignment 3
        //Date: 21-04-2015
        void CreateBranch(Branch New_Branch_Record);

        //To Implement
        //Method name: CreateUserBranch
        //Return Type: Void
        //Parameter type: Branch
        //Parsmenter Name: New_UserBranch_Record
        //Submission: Assignment 3
        //Date: 21-04-2015
        void CreateUserBranch(UserBranch New_UserBranch_Record);
        
        //To Implement
        //Method name: GetUserBranchCode
        //Parameter name: UserName
        //Parameter type: string
        //Return type: UserBranch
        //Submission: Required for Assignment 3
        //Date: 21-04-2015
        UserBranch GetUserBranchCode(string UserName);

        //To Implement
        //Method name: LogParcelMovement
        //Return Type: Void
        //Parameter type: Parcel_Tracking_Log
        //Parsmenter Name: New_Parcel_Movement_Record
        //Submission: Assignment 3
        //Date: 21-04-2015
        void LogParcelMovement(Parcel_Tracking_Log New_Parcel_Movement_Record);


        //To Implement
        //Method name: GetBranch
        //Parameter name: Branch_Code
        //Parameter type: String
        //Return type: Branch
        //Submission: Required for Assignment 3
        //Date: 23-04-2015
        Branch GetBranch(string Branch_Code);

        //To Implement
        //Method name: GetParcelTrackingLog
        //Parameter name: Tracking_Id
        //Parameter type: String
        //Return type: IList
        //Submission: Required for Assignment 3
        //Date: 23-04-2015
        IList<Parcel_Tracking_Log> GetParcelTrackingLog(string Tracking_Id);

        //To Implement
        //Method name: GetParcels
        //Parameter name: Username
        //Parameter type: string
        //Return type: Ilist
        //Submission: Assignment 4
        IList<Parcel> GetUserParcels(string Username);






    }
}
