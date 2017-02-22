/*
 * REST API Documentation for the MOTI Hired Equipment Tracking System (HETS) Application
 *
 * The Hired Equipment Program is for owners/operators who have a dump truck, bulldozer, backhoe or  other piece of equipment they want to hire out to the transportation ministry for day labour and  emergency projects.  The Hired Equipment Program distributes available work to local equipment owners. The program is  based on seniority and is designed to deliver work to registered users fairly and efficiently  through the development of local area call-out lists. 
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Moq;
using HETSAPI;
using HETSAPI.Models;
using HETSAPI.Controllers;
using HETSAPI.Services.Impl;

namespace HETSAPI.Test
{
	public class OwnerUnitTest 
    { 
		
		private readonly OwnerController _Owner;
		
		/// <summary>
        /// Setup the test
        /// </summary>        
		public OwnerUnitTest()
		{			
                    DbContextOptions<DbAppContext> options = new DbContextOptions<DbAppContext>();
                    Mock<DbAppContext> dbAppContext = new Mock<DbAppContext>(null, options);
			
                    /*
			
                    Here you will need to mock up the context.
			
            ItemType fakeItem = new ItemType(...);

            Mock<DbSet<ItemType>> mockList = MockDbSet.Create(fakeItem);

            dbAppContext.Setup(x => x.ModelEndpoint).Returns(mockItem.Object);

                    */

                    OwnerService _service = new OwnerService(dbAppContext.Object);
			
                    _Owner = new OwnerController (_service);

		}
	
		
		[Fact]
		/// <summary>
        /// Unit test for OwnersBulkPost
        /// </summary>
		public void TestOwnersBulkPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerController.OwnersBulkPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnersGet
        /// </summary>
		public void TestOwnersGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerController.OwnersGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnersIdDeletePost
        /// </summary>
		public void TestOwnersIdDeletePost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerController.OwnersIdDeletePost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnersIdGet
        /// </summary>
		public void TestOwnersIdGet()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerController.OwnersIdGet();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnersIdPut
        /// </summary>
		public void TestOwnersIdPut()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerController.OwnersIdPut();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
		
		[Fact]
		/// <summary>
        /// Unit test for OwnersPost
        /// </summary>
		public void TestOwnersPost()
		{
			// Add test code here
			// it may look like: 
			//  var result = _OwnerController.OwnersPost();
			//  Assert.True (result == expected-result);

            Assert.True(true);
		}		
        
    }
}
