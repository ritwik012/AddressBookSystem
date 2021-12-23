using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> addressList = new List<Contact>();
        Dictionary<string, List<Contact>> dictionary = new Dictionary<string, List<Contact>>();
        public void AddContact(Contact contact)
        {
            addressList.Add(contact);
            dictionary.Add(contact.FirstName, addressList);
        }
        public void EditContact(string name)
        {
            foreach (var contact in addressList)
            {
                if (contact.FirstName == name || contact.LastName == name)
                {
                    Console.WriteLine("Choose the field you want to edit : \n 1. First name \n 2. Last name \n 3. Address \n 4. City \n 5. State \n 6. Zip code \n 7. Phone Number \n 8. Email");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter you want to edit");
                            string first = Console.ReadLine();
                            contact.FirstName = first;
                            break;
                        case 2:
                            Console.WriteLine("Enter you want to edit");
                            string last = Console.ReadLine();
                            contact.LastName = last;
                            break;
                        case 3:
                            Console.WriteLine("Enter you want to edit");
                            string address = Console.ReadLine();
                            contact.Address = address;
                            break;
                        case 4:
                            Console.WriteLine("Enter you want to edit");
                            string city = Console.ReadLine();
                            contact.City = city;
                            break;
                        case 5:
                            Console.WriteLine("Enter you want to edit");
                            string state = Console.ReadLine();
                            contact.State = state;
                            break;
                        case 6:
                            Console.WriteLine("Enter you want to edit");
                            string zip = Console.ReadLine();
                            contact.Zip = zip;
                            break;
                        case 7:
                            Console.WriteLine("Enter you want to edit");
                            string phone = Console.ReadLine();
                            contact.PhoneNumber = phone;
                            break;
                        case 8:
                            Console.WriteLine("Enter you want to edit");
                            string email = Console.ReadLine();
                            contact.Email = email;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void DeleteContact(string name)
        {
            Contact delete = new Contact();
            foreach (var contact in addressList)
            {
                if (contact.FirstName == name || contact.LastName == name)
                {
                    delete = contact;
                }
            }
            addressList.Remove(delete);
            Console.WriteLine(name + " contact is deleted from the Address Book");
        }
        public void Display()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Here are the contacts in your Address Book : ");
            foreach (var contact in addressList)
            {
                Console.WriteLine(contact.FirstName + "\t" + contact.LastName + "\t" + contact.City + "\t" + contact.PhoneNumber);
            }
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        }
        public void AddUniqueContact()
        {
            foreach (var contact in addressList)
            {
                string uniqueName = Console.ReadLine();
                dictionary.Add(uniqueName, addressList);
            }
        }
        public void DisplayUniqueContacts()
        {
            Console.WriteLine("Enter name of dictionary to display that contact details");
            string name = Console.ReadLine().ToLower();
            foreach (var contacts in dictionary)
            {
                if (contacts.Key == name)
                {
                    foreach (var data in contacts.Value)
                    {
                        Console.WriteLine("The Contact details of " + data.FirstName + "are : \n" + data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.Zip + " " + data.PhoneNumber + " " + data.Email);
                    }
                }
            }
            Console.WriteLine("Oops Unique Contacts does not exist !!! Please create a Unique contact list");
            return;
        }
        public void CheckDuplicateEntry()
        {
            Console.WriteLine("Enter the name to check : ");
            string check = Console.ReadLine();
            var person = addressList.Find(e => e.FirstName.Equals(check));
            if (person != null)
            {
                Console.WriteLine("This Contact already exists with same First Name : " + check);
            }
            else
            {
                Console.WriteLine("You Can Proceed");
            }
        }
        public void CityList()
        {
            Console.WriteLine("Enter the City name to find persons : ");
            string city = Console.ReadLine();
            List<Contact> cityList = addressList.FindAll(e => e.City == city);
            foreach (var data in cityList)
            {
                Console.WriteLine("Found person {0} {1} in the Address Book , residing in the City {2}", data.FirstName, data.LastName, data.City);
            }
        }
        public void StateList()
        {
            Console.WriteLine("Enter the State name to find persons : ");
            string state = Console.ReadLine();
            List<Contact> stateList = addressList.FindAll(e => e.State == state);
            foreach (var data in stateList)
            {
                Console.WriteLine("Found person {0} {1} in the Address Book , residing in the State {2}", data.FirstName, data.LastName, data.State);
            }
        }
        public void CityCount()
        {
            Console.WriteLine("Enter the city name to find its count : ");
            string city = Console.ReadLine();
            List<Contact> cityList = addressList.FindAll(e => e.City == city);
            Console.WriteLine("The Number of contact persons in the city {0} are {1}", city, cityList.Count());
        }
        public void StateCount()
        {
            Console.WriteLine("Enter the state name to find its count : ");
            string state = Console.ReadLine();
            List<Contact> stateList = addressList.FindAll(e => e.State == state);
            Console.WriteLine("The number of contact persons in the state {0} are {1}", state, stateList.Count());
        }
        public void AddressBookSorting()
        {
            Console.WriteLine("Enter the Address Book name that you want to sort : ");
            string addressBookName = Console.ReadLine();
            if (dictionary.ContainsKey(addressBookName))
            {
                dictionary[addressBookName].Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                Display();
            }
            else
            {
                Console.WriteLine("The {0} Addressbook does not exist. Please Enter a Valid Addressbook Name. ", addressBookName);
            }
        }
        public void SortBy()
        {
            Console.WriteLine("Enter the Address Book name that you want to sort : ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine("How do you want the Sort the Addressbook : \n 1. Sort based on City \n 2. Sort based on State \n 3. Sort based on Zip");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    dictionary[addressBookName].Sort((x, y) => x.City.CompareTo(y.City));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
                case 2:
                    dictionary[addressBookName].Sort((x, y) => x.State.CompareTo(y.State));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
                case 3:
                    dictionary[addressBookName].Sort((x, y) => x.Zip.CompareTo(y.Zip));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
            }
        }
        public void ReadFile()
        {
            Console.WriteLine("The Contact details in the file after reading : ");
            string filePath = @"C:\Users\navee\OneDrive\Documents\Bridgelabz practice\AddressBookSystem\AddressBookSystem\Files\File.txt";
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);
        }
        public void WriteUsingStreamWriter()
        {
            Console.WriteLine("The Contact details in the file after writing : ");
            String filePath = @"C:\Users\navee\OneDrive\Documents\Bridgelabz practice\AddressBookSystem\AddressBookSystem\Files\File.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine("\nSNN : 173012021");
                writer.Close();
                Console.WriteLine(File.ReadAllText(filePath));
            }
        }
        public void ReadWriteAsCsv()
        {
            string importFilePath = @"C:\Users\navee\OneDrive\Documents\Bridgelabz practice\AddressBookSystem\AddressBookSystem\Files\import.csv";
            string exportFilePath = @"C:\Users\navee\OneDrive\Documents\Bridgelabz practice\AddressBookSystem\AddressBookSystem\Files\export.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Read data successfully from import csv");
                foreach (var data in records)
                {
                    Console.WriteLine(data.FirstName + "\t" + data.LastName + "\t" + data.Address + "\t" + data.City + "\t" + data.State + "\t" + data.Zip + "\t" + data.PhoneNumber + "\t" + data.Email + "\n");
                }
                Console.WriteLine("\n************  Now reading from import csv file and write to export csv file  ************");
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
                Console.WriteLine("The data is written in export csv file");
            }
        }
    }
}