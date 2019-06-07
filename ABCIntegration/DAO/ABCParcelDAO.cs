using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABCIntegration.IDAO;



namespace ABCIntegration.DAO
{
    public class ABCParcelDAO : ABCParcelIDAO
    {
        private ABCEntities _dbcontext;
        public ABCParcelDAO()
        {
            _dbcontext = new ABCEntities();
        }



        //To Implement
        //Method name: GetParcels
        //Method type: IList
        //Parameter name:
        //Parameter type:
        //Return type: Ilist
        //Submission: Assignment 1
        public  IList<Parcel> GetParcels()
        {
            IQueryable<Parcel> _allparcels;
            _allparcels = from allparcel in _dbcontext.Parcel select allparcel;
            return _allparcels.ToList<Parcel>();
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
            
            _dbcontext.Parcel.Add(New_Parcel_Record);
            _dbcontext.SaveChanges();
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
            IQueryable<Branch> _branches;
            _branches = from branch in _dbcontext.Branch select branch;
            return _branches.ToList<Branch>();
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
            IQueryable<Parcel> _recording;
            _recording = (from record in _dbcontext.Parcel
                          where record.parcel_id == Parcel_Id
                          select record);

            return _recording.ToList<Parcel>().First();
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

            Parcel recording = (from rec in _dbcontext.Parcel
                                where rec.parcel_id == Parcel_Record.parcel_id
                                select rec).ToList<Parcel>().First();

            recording.branch_code = Parcel_Record.branch_code;
            recording.Height = Parcel_Record.Height;
            recording.weight = Parcel_Record.weight;
            recording.width = Parcel_Record.width;
            recording.description = Parcel_Record.description;
            recording.shipping_addy_line1 = Parcel_Record.shipping_addy_line1;
            recording.shipping_addy_line2 = Parcel_Record.shipping_addy_line2;
            recording.shipping_city = Parcel_Record.shipping_city;
            recording.shipping_county = Parcel_Record.shipping_county;
            recording.shipping_country = Parcel_Record.shipping_country;
            recording.shipping_postcode = Parcel_Record.shipping_postcode;
            recording.shipping_mode = Parcel_Record.shipping_mode;

            _dbcontext.SaveChanges();
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

            _dbcontext.Parcel.Remove(Recording);
            _dbcontext.SaveChanges();
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

            Parcel recording = (from rec in _dbcontext.Parcel
                                where rec.parcel_id == Parcel_Record.parcel_id
                                select rec).ToList<Parcel>().First();

            recording.tracking_id = Parcel_Record.tracking_id;

            _dbcontext.SaveChanges();
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

            _dbcontext.Branch.Add(New_Branch_Record);
            _dbcontext.SaveChanges();
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
            _dbcontext.UserBranch.Add(New_UserBranch_Record);
            _dbcontext.SaveChanges();
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
            IQueryable<UserBranch> _recording;
            _recording = (from record in _dbcontext.UserBranch
                          where record.UserName == UserName
                          select record);

            return _recording.ToList<UserBranch>().First();

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
            _dbcontext.Parcel_Tracking_Log.Add(New_Parcel_Movement_Record);
            _dbcontext.SaveChanges();
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
            IQueryable<Branch> _recording;
            _recording = (from record in _dbcontext.Branch
                          where record.branch_code == Branch_Code
                          select record);

            return _recording.ToList<Branch>().First();
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
            IQueryable<Parcel_Tracking_Log> _trackingLog;
            _trackingLog = (from log in _dbcontext.Parcel_Tracking_Log
                            where log.tracking_id == Tracking_Id
                            select log);
            return _trackingLog.ToList<Parcel_Tracking_Log>();
        }


        //To Implement
        //Method name: GetParcels
        //Parameter name: Username
        //Parameter type: string
        //Return type: Ilist
        //Submission: Assignment 4
        public IList<Parcel> GetUserParcels(string Username)
        {
            IQueryable<Parcel> _allUserParcels;
            _allUserParcels = (from allparcel in _dbcontext.Parcel where allparcel.creator_id == Username  select allparcel);

            return _allUserParcels.ToList<Parcel>();
        }






    }

}
