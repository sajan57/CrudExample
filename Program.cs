
using System;
using System.Data.SqlClient;

namespace CrudOperation
{
    class Program
    {

        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\week1\Calculator\SimpleCalculator\CrudOperation\Database1.mdf; Integrated Security = True");
            con.Open();
            string output;
            do
            {
                Console.WriteLine("\t Main Menu\t\n");
                Console.WriteLine("Press 1 to Insert Records!");
                Console.WriteLine("Press 2 to Update Records!");
                Console.WriteLine("Press 3 to Delete Records!");
                Console.WriteLine("Press 4 to View Records!");

                int Command = int.Parse(Console.ReadLine());
                switch (Command)
                {
                    case 1:

                        // for insert the data in database:
                        string UserName, Password;
                        Console.WriteLine("Enter Username and Password");
                        UserName = Console.ReadLine();
                        Password = Console.ReadLine();

                        SqlCommand cmd = new SqlCommand("Insert into tbl1_Login(UserName,Password) values('" + UserName + "','" + Password + "')", con);


                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            Console.WriteLine("Insertion Successfull");

                        }
                        break;



                    /// for update Data From the DataBase.
                    case 2:
                        string u_UserName, u_Password;
                        int Id;
                        Console.WriteLine("Enter the employee Id that would you like to update");
                        Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Username  that would you like to update");
                        u_UserName = Console.ReadLine();

                        Console.WriteLine("Enter Password  that would you like to update");
                        u_Password = Console.ReadLine();

                        string updateQuery = "Update tbl1_Login set UserName= '" + u_UserName + "' , Password ='" + u_Password + "' where Id = " + Id + "";

                        SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                        //updateCommand.Parameters.Add(new SqlParameter("Id", 3));
                        //updateCommand.Parameters.Add(new SqlParameter("Password", 986377));

                        updateCommand.ExecuteNonQuery();

                        Console.WriteLine("Update Sucessfully");
                        Console.WriteLine("Done! Press enter  to move the next step:");
                        break;





                    /// for Delete Data From Login.
                    case 3:
                        int d_Id;
                        Console.WriteLine("Enter the employee Id that would you like to delete");
                        d_Id = int.Parse(Console.ReadLine());


                        SqlCommand DeleteCommand = new SqlCommand("Delete from tbl1_Login where Id= " + d_Id, con);
                        //DeleteCommand.Parameters.Add(new SqlParameter("Id", 4));
                        Console.WriteLine("Command executed! Total rows affected are " + DeleteCommand.ExecuteNonQuery());

                        Console.WriteLine("Delete  Sucessfully");
                        Console.WriteLine("Done! Press enter  to move the next step:");



                        break;


                    /////// for select data from the table
                    case 4:

                        SqlCommand command = new SqlCommand("SELECT * FROM Tbl1_Login", con);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Emp Id\t\t\t EmpName \t EmpPassword\t");
                            while (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0} \t\t\t | {1} \t | {2}",
                                    reader[0], reader[1], reader[2]));
                            }
                        }
                        Console.WriteLine("Data displayed successfully!");
                        Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                        Console.ReadLine();
                        Console.Clear();

                        con.Close();
                        break;

                    default:
                        Console.WriteLine("Wrong Input");
                        break;



                }

                Console.WriteLine("Do you want to c ontinue?");
                output = Console.ReadLine();
            } while (output != "No");
        }
    }
}
