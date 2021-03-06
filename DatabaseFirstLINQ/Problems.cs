using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne();
            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            //ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
            BonusOne();
            //BonusTwo();
            //BonusThree();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            var usernames = _context.Users;
            foreach (User user in usernames)

            {
                Console.WriteLine(user.Id);
            }
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count

        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            var products = _context.Products;
            var listOfProduct = products.Where(n => n.Price >= 150);

            foreach( Product product in listOfProduct)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
            }

            // Write a LINQ query that gets each product where the products price is greater than $150.
            // Then print the name and price of each product from the above query to the console.

        }

        private void ProblemFour()
        {
            var products = _context.Products.Where(p => p.Name.Contains("s"));
            //var products2 = products.Where(p => p.Name.Contains("s"));

            //var products = _context.Products.Contains(p => p.Name == "s").ToList();
            //var letteredProducts = products.Where(p => p.Name == "s");

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
            }

            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.

        }

        private void ProblemFive()
        {
            var userRegistered = _context.Users.Where(y => y.RegistrationDate.Value.Year <= 2016 );
            //var users = _context.Users.Where(p => DateTime.ParseExact(p.RegistrationDate, "dd/MM/yyyy", null).Year <= 2016).ToList();
            foreach (User user in userRegistered)
            {
                Console.WriteLine(user.Email);
                Console.WriteLine(user.RegistrationDate);

            }


            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.

        }

        private void ProblemSix()
        {
            var userRegistedDates = _context.Users.Where(d => d.RegistrationDate.Value.Year >= 2016 && d.RegistrationDate.Value.Year <= 2018);

            foreach(User user in userRegistedDates)
            {
                Console.WriteLine(user.RegistrationDate);
                Console.WriteLine(user.Email);
            }
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.

        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }

        private void ProblemEight()
        {
            var userNameInfo = _context.ShoppingCarts.Include(g => g.Product).Where(g => g.User.Email == "afton@gmail.com");

            foreach (ShoppingCart cart in userNameInfo)
            {
                Console.WriteLine(cart.Product.Name);
                Console.WriteLine(cart.Product.Price);
                Console.WriteLine(cart.Quantity);
            }
                
             // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            // Then print the product's name, price, and quantity to the console.

        }

        private void ProblemNine()
        {
            var odaLumpSum = _context.ShoppingCarts.Include(o => o.Product).Where(o => o.User.Email == "oda@gmail.com").Select(sc => sc.Product.Price).Sum();

            
            {
                Console.WriteLine(odaLumpSum);
            }
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.

        }

        private void ProblemTen()
        {
            var employeeRole = _context.UserRoles.Include(er => er.Role).Include(er => er.User).Where(er => er.Role.RoleName == "Employee");
            var employeeProduct = _context.ShoppingCarts.Include(ep => ep.Product);

            foreach (UserRole user in employeeRole)
            {
                Console.WriteLine(user.User.Email);
               
            }
            foreach (ShoppingCart cart in employeeProduct)
            {
                Console.WriteLine(cart.Product.Price);
                Console.WriteLine(cart.Product.Name);
                Console.WriteLine(cart.Quantity);
            }

            //var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");

             //var userNameInfo = _context.ShoppingCarts.Include(g => g.Product).Where(g => g.User.Email == "afton@gmail.com");

            // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
            // Then print the user's email as well as the product's name, price, and quantity to the console.

        }

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.
            Product newProduct = new Product()
            {
                Name = "PlayStaion 5",
                Description = "Newest generation of Sony's Best selling product.",
                Price = 800,
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();


        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var addProductToUser = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u =>u.Id).SingleOrDefault();
            var addedProduct = _context.Products.Where(p=> p.Name == "PlayStaion 5").Select(p=> p.Id).SingleOrDefault();
            //var addedTotal = _context.ShoppingCarts.

            ShoppingCart newShoppingCart = new ShoppingCart()
            {
                UserId = addProductToUser,
                ProductId = addedProduct
            };
            _context.ShoppingCarts.Add(newShoppingCart);
            _context.SaveChanges();

        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {

            // Update the price of the product you created to something different using LINQ.
            var productPrice = _context.Products.Where(p => p.Price == 800).SingleOrDefault();
            productPrice.Price = 1000;
            _context.Products.Update(productPrice);
            _context.SaveChanges();

        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var delRole = _context.UserRoles.Where(ur => ur.User.Email == "oda@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(delRole);

            _context.SaveChanges();
        }


        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var delUser = _context.Users.Where(u => u.Email == "oda@gmail.com").SingleOrDefault();
            _context.Users.Remove(delUser);
            _context.SaveChanges();
        }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".

            Console.WriteLine("Please Enter your Email: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your Password: ");
            string password = Console.ReadLine();
            Console.WriteLine($"The username entered was {username} and the password you used was {password}. ");
          
            var authUser= _context.Users.Where(u => u.Email == username).SingleOrDefault();
            var authPassword = _context.Users.Where(u => u.Password == password).SingleOrDefault();

            if( authUser == null || authPassword == null)
            {
                Console.WriteLine("Invalid Input!");
            }
            else
            {
                Console.WriteLine("Signed In!");
            }
            //var authUser = _context.Users.Where(u => u.Email == username).SingleOrDefault();


            //User newUser = new User()

            //_context.Users.Add(newUser);
            //_context.SaveChanges();





        }

        private void BonusTwo()
        {

            // Write a query that finds the total of every users shopping cart products using LINQ.
            // Display the total of each users shopping cart as well as the total of the toals to the console.

            var aftonCartSum = _context.ShoppingCarts.Include(o => o.Product).Where(o => o.User.Email == "afton@gmail.com").Select(sc => sc.Product.Price).Sum();
            var bibiCartSum = _context.ShoppingCarts.Include(o => o.Product).Where(o => o.User.Email == "bibi@gmail.com").Select(sc => sc.Product.Price).Sum();
            var janettCartSum = _context.ShoppingCarts.Include(o => o.Product).Where(o => o.User.Email == "janett@gmail.com").Select(sc => sc.Product.Price).Sum();
            var garyCartSum = _context.ShoppingCarts.Include(o => o.Product).Where(o => o.User.Email == "gary@gmail.com").Select(sc => sc.Product.Price).Sum();
            var mikeCartSum = _context.ShoppingCarts.Include(o => o.Product).Where(o => o.User.Email == "mike@gmail.com").Select(sc => sc.Product.Price).Sum();


            Console.WriteLine(aftonCartSum);
            Console.WriteLine(bibiCartSum);
            Console.WriteLine(janettCartSum);
            Console.WriteLine(garyCartSum);
            Console.WriteLine(mikeCartSum);
            Console.WriteLine(aftonCartSum+bibiCartSum+janettCartSum+garyCartSum+mikeCartSum);

        }

        // BIG ONE
        private void BonusThree()
        {
            // 1. Create functionality for a user to sign in via the console
            // 2. If the user succesfully signs in
            // a. Give them a menu where they perform the following actions within the console
            // View the products in their shopping cart
            // View all products in the Products table
            // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
            // Remove a product from their shopping cart
            // 3. If the user does not succesfully sing in
            // a. Display "Invalid Email or Password"
            // b. Re-prompt the user for credentials

        }

    }
}
