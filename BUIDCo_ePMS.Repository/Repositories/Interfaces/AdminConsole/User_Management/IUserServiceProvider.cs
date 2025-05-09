﻿using BUIDCO.Domain.AdminConsole.User_Management;
namespace BUIDCO.Repository.Contract.Contract.AdminConsole.User_Management
{
    public interface IUserServiceProvider
    {
        int CreateUser(User objUser);
        int EditUser(User objUser);
        int DeleteUser(User objUser);
        int ActivateUser(User objUser);
        int DeActivateUser(User objUser);
        IList<User> GetAllUsers(User objUser);
        string GetFullNameFromId(int intUserId);
        IList<User> GetDetails(User objUser);

        IList<User> PopUpDropDown1();
        int GetLevelDTlID(string LvlDtlId);
        int GetPosition(string LevelId);
        int GetSubAdminPrev(string userid);
        IList<UserDetail> GetLevelDetailsByuser(int ParentId);
        IList<USEREXPORT> GetuserExport();
        IList<User> PopUpDropDown3(string Id);
        IList<User> PopUpDropDown4(string Id);
        IList<User> GetDesigInfo(string Id);
        IList<User> GetTGradeDetail(string Id);
        IList<User> UserGetLevel(string Id);
        IList<User> GetPosition2(string Id);
        IList<User> UserGetHierarchyID(string Id);
        IList<User> UserGetParentID(string Id);
        IList<User> PopUpDropDown5(string Id);
        IList<User> PopUpDropDown6();
        IList<User> PopUpDropDown7();
        IList<User> PopUpDropDown8();
        IList<User> PopUpDropDown9(string Id);
        string Message(string strActionCode, string strDuplicVal, string strUserId);
        IList<User> FillPermissionReport(int Location,int Access,int Plink);
        IList<User> FillParentSO(int Location);
        IList<User> FillChildSO(int RptID);
        IList<User> FillUserRA();
        IList<LevelDetail> GetLevelDetails(int hirachyId);
        IList<LevelDetail> GetLevelDetailsByParentId(int ParentId);
        IList<Location> GetLocation();
        IList<Designation> GetDesignations();
        IList<User> GetUserById(int UserId , string ActionCode);
        int ValidateUser(User user);

        int LDAPValidateUser(User user);
        User LDAPGetUserInfo(User user);
        User GetUserInfo(User user);
        int ChangePasswod(User user);
        IList<LinkAccess> GetLinkAccessByUserId(int UserId);
    }
}