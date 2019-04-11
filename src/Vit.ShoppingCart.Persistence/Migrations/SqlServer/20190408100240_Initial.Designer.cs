﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vit.ShoppingCart.Persistence;

namespace Vit.ShoppingCart.Persistence.Migrations.SqlServer
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20190408100240_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vit.ShoppingCart.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("TotalAmount");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Vit.ShoppingCart.Domain.Orders.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<Guid?>("OrderId");

                    b.Property<Guid?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Vit.ShoppingCart.Domain.Payments.Payment", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<decimal>("Amount");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Vit.ShoppingCart.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("IsBestseller");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("Vit.ShoppingCart.Domain.Books.Book", b =>
                {
                    b.HasBaseType("Vit.ShoppingCart.Domain.Products.Product");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Title");

                    b.HasDiscriminator().HasValue("Book");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c68f38fc-0a77-4a83-b1f1-ea6fbc4f830d"),
                            Description = "Dig deep and master the intricacies of the common language runtime, C#, and .NET development. Led by programming expert Jeffrey Richter, a longtime consultant to the Microsoft .NET team - you’ll gain pragmatic insights for building robust, reliable, and responsive apps and components.",
                            IsBestseller = false,
                            Name = "CLR via C#",
                            Price = 35.42m,
                            Rating = 4.8m,
                            Author = "Jeffrey Richter",
                            ISBN = "0735667454",
                            Publisher = "Microsoft Press, 2012",
                            Title = "CLR via C#"
                        },
                        new
                        {
                            Id = new Guid("67aa9820-c75c-49ef-9180-cc865d26ba6f"),
                            Description = "This book does not just teach you how the CLR works – it teaches you exactly what you need to do now to obtain the best performance today. It will expertly guide you through the nuts and bolts of extreme performance optimization in .NET, complete with in-depth examinations of CLR functionality, free tool recommendations and tutorials, useful anecdotes, and step-by-step guides to measure and improve performance.",
                            IsBestseller = false,
                            Name = "High-Performance .NET Code",
                            Price = 34.99m,
                            Rating = 4.4m,
                            Author = "Ben Watson",
                            ISBN = "0990583457",
                            Publisher = "Ben Watson, 2018",
                            Title = "Writing High-Performance .NET Code"
                        },
                        new
                        {
                            Id = new Guid("93bde34a-8f64-4170-939c-9891af75c00d"),
                            Description = "Functional Concurrency in .NET teaches readers how to build concurrent and scalable programs in .NET using the functional paradigm. This intermediate-level guide is aimed at developers, architects, and passionate computer programmers.",
                            IsBestseller = false,
                            Name = "Concurrency in .NET",
                            Price = 45.99m,
                            Rating = 5m,
                            Author = "Mr Riccardo Terrell",
                            ISBN = "9781617292996",
                            Publisher = "Manning Publications, 2018",
                            Title = "Concurrency in .NET: Modern patterns of concurrent and parallel programming"
                        },
                        new
                        {
                            Id = new Guid("a95b0a23-ebd4-4c6e-988c-226a96a94503"),
                            Description = "Building upon the success of best-sellers The Clean Coder and Clean Code, legendary software craftsman Robert C. \"Uncle Bob\" Martin shows how to bring greater professionalism and discipline to application architecture and design.",
                            IsBestseller = false,
                            Name = "Clean Architecture",
                            Price = 19.79m,
                            Rating = 3.8m,
                            Author = " Robert C. Martin",
                            ISBN = "0134494164",
                            Publisher = "Prentice Hall, 2017",
                            Title = "Clean Architecture: A Craftsman's Guide to Software Structure and Design"
                        },
                        new
                        {
                            Id = new Guid("460dd749-045f-48f1-90ab-123bba57d248"),
                            Description = "By applying this book’s principles, you can create code that accommodates new requirements and unforeseen scenarios without significant rewrites. Gary McLean Hall describes Agile best practices, principles, and patterns for designing and writing code that can evolve more quickly and easily, with fewer errors, because it doesn’t impede change.",
                            IsBestseller = false,
                            Name = "Adaptive Code",
                            Price = 26.74m,
                            Rating = 4.4m,
                            Author = "Gary McLean Hall",
                            ISBN = "1509302581",
                            Publisher = "Microsoft Press, 2017",
                            Title = "Adaptive Code: Agile coding with design patterns and SOLID principles"
                        },
                        new
                        {
                            Id = new Guid("1bd9b269-ca52-405d-8fd9-e13d78253999"),
                            Description = "This book will walk you through the process of developing an e-commerce application from start to finish, utilizing an ASP.NET Core web API and Vue.js Single-Page Application (SPA) frontend.",
                            IsBestseller = false,
                            Name = "ASP.NET Core 2nd and Vue.js",
                            Price = 32.99m,
                            Rating = 5m,
                            Author = "Stuart Ratcliffe",
                            ISBN = "1788839463",
                            Publisher = "Packt Publishing, 2018",
                            Title = "ASP.NET Core 2nd and Vue.js"
                        },
                        new
                        {
                            Id = new Guid("0f2931df-0586-41be-b486-b69197745587"),
                            Description = "Distributed systems have become more fine-grained in the past 10 years, shifting from code-heavy monolithic applications to smaller, self-contained microservices. But developing these systems brings its own set of headaches. With lots of examples and practical advice, the second edition of this practical book takes a holistic view of the topics that system architects and administrators must consider when building, managing, and evolving microservice architectures. Microservice technologies are moving quickly, and this revised edition gets you up to date with a new chapter on serverless and cloud-native applications, expanded coverage of user interfaces, more hands-on code examples, and other additions throughout the book. Author Sam Newman provides you with a firm grounding in the concepts while diving into current solutions for modeling, integrating, testing, deploying, and monitoring your own autonomous services. You'll follow a fictional company throughout the book to learn how building a microservice architecture affects a single domain.",
                            IsBestseller = false,
                            Name = "Building Microservices",
                            Price = 31.19m,
                            Rating = 4m,
                            Author = "Sam Newman",
                            ISBN = "1492034029",
                            Publisher = "O′Reilly, 2015",
                            Title = "Building Microservices"
                        },
                        new
                        {
                            Id = new Guid("5c166ccf-8287-4c17-a8ba-6818ec4589ad"),
                            Description = "Reading and storing data is a core part of any application, and .NET developers want database access to be easy and intuitive. Entity framework Core is a .NET library designed to simplify data persistence, bridging the mismatch between the different structures of object-oriented code and relational databases.",
                            IsBestseller = false,
                            Name = "Entity Framework Core in Action",
                            Price = 27.99m,
                            Rating = 5m,
                            Author = "Jon Smith",
                            ISBN = "161729456X",
                            Publisher = "Manning Publications, 2018",
                            Title = "Entity Framework Core in Action"
                        },
                        new
                        {
                            Id = new Guid("b4c3a3d1-c31d-4516-8c30-79dac3a92663"),
                            Description = "Ruby’s widely admired simplicity has a downside: too many Ruby and Rails applications have been created without concern for their long-term maintenance or evolution. The Web is awash in Ruby code that is now virtually impossible to change or extend. This text helps you solve that problem by using powerful real-world object-oriented design techniques, thoroughly explained via simple and practical Ruby examples.",
                            IsBestseller = false,
                            Name = "Practical Object-Oriented Design",
                            Price = 32.10m,
                            Rating = 4.7m,
                            Author = "Sandi Metz",
                            ISBN = "9780134456478",
                            Publisher = "Addison Wesley, 2018",
                            Title = "Practical Object-Oriented Design: An Agile Primer Using Ruby"
                        },
                        new
                        {
                            Id = new Guid("4f5b546b-437d-4869-8a7b-a76d529b962d"),
                            Description = "This is not a book about specific technologies. It offers readers a systematic approach to domain-driven design, presenting an extensive set of design best practices, experience-based techniques, and fundamental principles that facilitate the development of software projects facing complex domains. Intertwining design and development practice, this book incorporates numerous examples based on actual projects to illustrate the application of domain-driven design to real-world software development.",
                            IsBestseller = false,
                            Name = "Domain-Driven Design",
                            Price = 41.30m,
                            Rating = 3.8m,
                            Author = "Eric Evans",
                            ISBN = "0321125215",
                            Publisher = "Addison Wesley, 2003",
                            Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                        },
                        new
                        {
                            Id = new Guid("117fa0bf-6bcd-475f-a508-67171247ada6"),
                            Description = "Even bad code can function. But if code isn’t clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn’t have to be that way. Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship . Martin has teamed up with his colleagues from Object Mentor to distill their best agile practice of cleaning code “on the fly” into a book that will instill within you the values of a software craftsman and make you a better programmer—but only if you work at it. What kind of work will you be doing? You’ll be reading code—lots of code. And you will be challenged to think about what’s right about that code, and what’s wrong with it. More importantly, you will be challenged to reassess your professional values and your commitment to your craft. Clean Code is divided into three parts. The first describes the principles, patterns, and practices of writing clean code. The second part consists of several case studies of increasing complexity. Each case study is an exercise in cleaning up code—of transforming a code base that has some problems into one that is sound and efficient. The third part is the payoff: a single chapter containing a list of heuristics and “smells” gathered while creating the case studies. The result is a knowledge base that describes the way we think when we write, read, and clean code. Readers will come away from this book understanding How to tell the difference between good and bad code How to write good code and how to transform bad code into good code How to create good names, good functions, good objects, and good classes How to format code for maximum readability How to implement complete error handling without obscuring code logic How to unit test and practice test-driven development This book is a must for any developer, software engineer, project manager, team lead, or systems analyst with an interest in producing better code.",
                            IsBestseller = false,
                            Name = "Clean Code",
                            Price = 33.56m,
                            Rating = 4.4m,
                            Author = "Robert Martin",
                            ISBN = "9780132350884",
                            Publisher = "Prentice Hall, 2008",
                            Title = "Clean Code: A Handbook of Agile Software Craftsmanship"
                        },
                        new
                        {
                            Id = new Guid("0b110160-1f4c-4633-92c8-6ee07e2e31a3"),
                            Description = "Written by an expert, Quantum Physics for Babies is a colorfully simple introduction to the principle that gives quantum physics its name. Babies (and grownups!) will discover that the wild world of atoms never comes to a standstill. With a tongue-in-cheek approach that adults will love, this installment of the Baby University board book series is the perfect way to introduce basic concepts to even the youngest scientists. After all, it's never too early to become a quantum physicist!",
                            IsBestseller = true,
                            Name = "Quantum Physics for Babies",
                            Price = 13.86m,
                            Rating = 4.1m,
                            Author = "Chris Ferrie",
                            ISBN = "1492656224",
                            Publisher = "Sourcebooks Jabberwocky, 2017",
                            Title = "Quantum Physics for Babies"
                        },
                        new
                        {
                            Id = new Guid("08d4be48-1993-4862-ab14-c2226bf1270e"),
                            Description = "Understand .NET memory management internal workings, pitfalls, and techniques in order to effectively avoid a wide range of performance and scalability problems in your software. Despite automatic memory management in .NET, there are many advantages to be found in understanding how .NET memory works and how you can best write software that interacts with it efficiently and effectively. Pro .NET Memory Management is your comprehensive guide to writing better software by understanding and working with memory management in .NET.",
                            IsBestseller = false,
                            Name = "Pro .NET Memory Management",
                            Price = 38.23m,
                            Rating = 5m,
                            Author = "Konrad Kokosa",
                            ISBN = "9781484240274",
                            Publisher = "Apress, 2018",
                            Title = "Pro .NET Memory Management: For Better Code, Performance, and Scalability"
                        },
                        new
                        {
                            Id = new Guid("f5c43b4c-22dc-4ecb-b0bc-90c73444eee4"),
                            Description = "This book starts with an introduction to the core concepts of .NET memory management and garbage collection, and then quickly layers on additional details and intricacies. Once you're up to speed, you can dive into the guided troubleshooting tour, and tips for engineering your application to maximise performance. And to finish off, take a look at some more sophisticated considerations, and even a peek inside the Windows memory model.",
                            IsBestseller = false,
                            Name = "Under the Hood of .NET Memory Management",
                            Price = 29.49m,
                            Rating = 4.3m,
                            Author = "Chris Farrell, Nick Harrison",
                            ISBN = "1906434748",
                            Publisher = "Red Gate Books, 2013",
                            Title = "Under the Hood of .NET Memory Management"
                        },
                        new
                        {
                            Id = new Guid("3f52310d-25d4-4f9d-8f72-4d6c87042390"),
                            Description = "In 1994, DESIGN PATTERNS changed the landscape of object-oriented development by introducing classic Solutions to recurring design problems. In 1999, REFACTORING revolutionized design by introducing an effective process for improving code. With the highly-anticipated REFACTORING TO PATTERNS, Joshua Kerievsky has changed our approach to design by forever uniting patterns with the evolutionary process of refactoring. This book introduces the theory and practice of pattern-directed refactorings: sequences of low-level refactorings that allow designers to safely move designs to, towards, or away from pattern implementations. Using code from real-world projects, Kerievsky documents the thinking and steps underlying over two dozed pattern-based design transformations. Along the way he offers insights into pattern differences and how to implement patterns in the simplest possible ways.",
                            IsBestseller = false,
                            Name = "Refactoring to Patterns",
                            Price = 61.89m,
                            Rating = 4.1m,
                            Author = "Joshua Kerievsky",
                            ISBN = "0321213351",
                            Publisher = "Addison-Wesley Professional, 2004",
                            Title = "Refactoring to Patterns"
                        },
                        new
                        {
                            Id = new Guid("501791ad-7a1c-464a-a585-7fd000a0e253"),
                            Description = "\"Programming Legend Charles Petzold unlocks the secrets of the extraordinary and prescient 1936 paper by Alan M. Turing Mathematician Alan Turing invented an imaginary computer known as the Turing Machine; in an age before computers, he explored the concept of what it meant to be computable, creating the field of computability theory in the process, a foundation of present-day computer programming. The book expands Turing's original 36-page paper with additional background chapters and extensive annotations; the author elaborates on and clarifies many of Turing's statements, making the original difficult-to-read document accessible to present day programmers, computer science majors, math geeks, and others. Interwoven into the narrative are the highlights of Turing's own life: his years at Cambridge and Princeton, his secret work in cryptanalysis during World War II, his involvement in seminal computer projects, his speculations about artificial intelligence, his arrest and prosecution for the crime of gross indecency and his early death by apparent suicide at the age of 41.",
                            IsBestseller = false,
                            Name = "The Annotated Turing",
                            Price = 16.33m,
                            Rating = 4.5m,
                            Author = " Charles Petzold",
                            ISBN = "0470229055",
                            Publisher = "Wiley, 2008",
                            Title = "The Annotated Turing: A Guided Tour Through Alan Turing's Historic Paper on Computability and the Turing Machine"
                        });
                });

            modelBuilder.Entity("Vit.ShoppingCart.Domain.Orders.OrderItem", b =>
                {
                    b.HasOne("Vit.ShoppingCart.Domain.Orders.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("Vit.ShoppingCart.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Vit.ShoppingCart.Domain.Payments.Payment", b =>
                {
                    b.HasOne("Vit.ShoppingCart.Domain.Orders.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Vit.ShoppingCart.Domain.Payments.Payment", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
