using System;
using System.Data.SqlClient;

namespace AppraisalValidation
{
    public class validation
    {

        static SqlDataReader dr;

               public static void Connection()
        {
            int k,j;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("===============******=================== Appraisal History of Employee =======================******===========\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            
            
            Console.WriteLine("1. add New Employee information..\n 2. List of Employee who joined as 'Intern' And now are 'Manger'.\n3. Employee with maximum Appraisal.\n4. Employee role was not changed after Appraisal.\n5. Employee who did not have Appraisal.\n6. Exit.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n ==============******==========================******==================================******===============");
            Console.WriteLine("\nEnter Your Choice Of Number");
            do
            {
                k = Convert.ToInt32(Console.ReadLine());
                if(k == 1)
                {
                    Console.WriteLine("----*---- Add Employee Details ----*----\n");
                    Console.WriteLine("1.Add Employee EmpId EmpNmae CurrentRole JoinDatae. \n2. Add new Roles \n3. Modify Roles\n4. Delete Roles\n5. Exit\n");
                    Console.WriteLine("Enter Your Choice");
                    do
                    {
                        j = Convert.ToInt32(Console.ReadLine());
                        if (j == 1)
                        {
                            int EmpId;
                            String EmpName;
                            String CurrentRole;
                            Double JoinDate;
                            Console.WriteLine("Enter EmpId EmpName CurrentRole JoinDatae.");
                            EmpId = Convert.ToInt32(Console.ReadLine());
                            EmpName = Console.ReadLine();
                            CurrentRole = Console.ReadLine();
                            JoinDate = Convert.ToDouble(Console.ReadLine());
                            SqlConnection con = new SqlConnection("data source=DESKTOP-K9O3B3O;initial catalog=AppraisalProject; integrated security=true;");
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into Employee(" + EmpId + " ,'" + EmpName + "'," + CurrentRole + ",'" + JoinDate + "')", con);
                            try
                            {
                                dr = cmd.ExecuteReader();
                            }
                              catch (System.Data.SqlClient.SqlException ex)
                            {
                            string msg = "Insert Error";
                            msg += ex.Message;
                            }
                            Console.WriteLine("Record Insertd");
                            Console.ReadKey();
                            con.Close();
                                Console.WriteLine("\nEnter Your Choice");
                        }
                        else if (j == 2)
                        {
                            String EmpRole;
                            Console.WriteLine("Enter new Role");
                            EmpRole = Console.ReadLine();
                            Console.WriteLine(EmpRole);
                            Console.WriteLine("\nEnter Your Choice");
                        }
                        else if (j == 3)
                        {
                            String newRole;
                            Console.WriteLine("Modify Role");
                            newRole = Console.ReadLine();
                            Console.WriteLine(newRole);
                            Console.WriteLine("\nEnter Your Choice");

                        }
                        else if (j == 4)
                        {
                            String deleteRole;
                            Console.WriteLine("Delete Role");
                            deleteRole = Console.ReadLine();
                            Console.WriteLine(deleteRole);
                            Console.WriteLine("\nEnter Your Choice");

                        }
                        else if (j == 5)
                        {
                            Console.WriteLine("Data Added SucessFully...!\n");
                            Console.WriteLine("Enter Your Choice");
                        }
                        else
                        {
                            Console.WriteLine("Enter Correct Choice");
                        }
                    } while (j != 5);
                }
               else if (k == 2)

                {
                    Console.WriteLine("List of Employee who joined as 'Intern' And now are 'Manger' :- \n");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-K9O3B3O;initial catalog=AppraisalProject; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from EmpAppraisal where CurrentRole = 'Intern' and NewRole = 'Manager'", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("Empid\tCurrentRole\tNewRole\t\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t{1}\t\t{2}\t\n", dr[0], dr[1], dr[2]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice Of Number");
                }
                else if (k == 3)
                {
                    Console.WriteLine("Employee with maximum Appraisal :- \n");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-K9O3B3O;initial catalog=AppraisalProject; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" select CurrentRole, NewRole, EmpId from EmpAppraisal where roleid= (select  MAX(roleid) from EmpAppraisal)", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("CurrentRoll\t");
                    Console.Write("NewRoll\t");
                    Console.Write("Empid\t");
                    while (dr.Read())
                    {
                        Console.Write("\n{0}\t\t{1}\t{2}",  dr[0], dr[1], dr[2]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice  Of Number");
                }
                else if (k == 4)
                {
                    Console.WriteLine("Employee role was not changed after Appraisal :-\n");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-K9O3B3O;initial catalog=AppraisalProject; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" select emp.EmpName,ap.CurrentRole,ap.NewRole from Employee emp inner join EmpAppraisal ap on emp.EmpId=ap.EmpId where CurrentRole=NewRole", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("EmpName\t\tCurrentRole\t\tNewRole\t\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t\t{1}\t\t{2}\t\n", dr[0], dr[1], dr[2]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice Of Number");

                }
                else if (k == 5)
                {
                    Console.WriteLine("Employee who did not have Appraisal :-\n");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-K9O3B3O;initial catalog=AppraisalProject; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from EmpAppraisal where  NewRole='Null'", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("Empid\tCurrentRole\t\tNewRole\t\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t{1}\t{2}\t\n", dr[0], dr[1], dr[2]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice Of Number");
                }
                else if (k == 6)
                {
                    Console.WriteLine("thank You '");
                }
                else
                {
                    Console.WriteLine("Enter Correct Choice Of Number");
                }
            } while (k != 6);
        }
    }
}
