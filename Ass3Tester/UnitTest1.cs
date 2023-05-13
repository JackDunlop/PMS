//using Ass3;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Ass3Tester
//{
//    public class Tests
//    {
//        private StringWriter consoleOutput;
//        private StringReader consoleInput;
//        private Job job;

//        [SetUp]
//        public void Setup()
//        {
//            consoleOutput = new StringWriter();
//            Console.SetOut(consoleOutput);
//            job = new Job();
//        }

//        private void SetInput(string input)
//        {
//            consoleInput = new StringReader(input);
//            Console.SetIn(consoleInput);
//        }

//        [Test]
//        public void TestAddJob()
//        {
//            var jobs = new Dictionary<string, Job>();

//            SetInput("NewJob\n2\nDep1\nDep2\n");

//            job.AddJob(jobs);

//            Assert.IsTrue(jobs.ContainsKey("NewJob"));
//            Assert.AreEqual(2, jobs["NewJob"].JobTime);
//            Assert.Contains("Dep1", jobs["NewJob"].JobDependencies.ToList());
//            Assert.Contains("Dep2", jobs["NewJob"].JobDependencies.ToList());
//        }

//        [Test]
//        public void TestUpdateJob()
//        {
//            var jobs = new Dictionary<string, Job>
//            {
//                { "TestJob", new Job("TestJob", 5) }
//            };

//            SetInput("TestJob\n10\n");

//            job.UpdateJob(jobs);

//            Assert.AreEqual(10, jobs["TestJob"].JobTime);
//        }

//        [Test]
//        public void TestRemoveJob()
//        {
//            var jobs = new Dictionary<string, Job>
//            {
//                { "TestJob", new Job("TestJob", 5) }
//            };

//            SetInput("TestJob\n");

//            job.RemoveJob(jobs);

//            Assert.IsFalse(jobs.ContainsKey("TestJob"));
//        }
//    }
//}