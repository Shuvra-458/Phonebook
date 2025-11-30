using System;

namespace Contact_Management.Models
{
    public class Contact
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Phone {get; set;}
        public string Email {get; set;}
        public string Address {get; set;}

        public override string ToString () => 
            $"[{Id}] | {Name} | {Phone} | {Email} | {Address}";
    }
}