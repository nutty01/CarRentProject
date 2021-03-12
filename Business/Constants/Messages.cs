using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car Added";
        public static string CarUpdated = "Car Updated";
        public static string CarDeleted = "Car Deleted"; 
        public static string BrandAdded = "Brand Added";
        public static string BrandUpdated = "Brand Updated";
        public static string BrandDeleted = "Brand Deleted";
        public static string ColorAdded = "Color Added";
        public static string ColorUpdated = "Color Updated";
        public static string ColorDeleted = "Color Deleted";
        public static string CarInvalid = "Car is invalid";
        public static string BrandsListed = "Brands listed";
        public static string CarsListed = "Cars listed";
        public static string UserAdded = "User Added";
        public static string CarNotAvailable = "Car is not available";
        public static string CarImagesListed="Car Images listed";
        public static string CarImageAdded="Car Image added";
        public static string CarImageDeleted="Car Image deleted";
        public static string CarImageUpdated="Car Image updated";
        public static string CarImageLimitExceeded="Maximum 5 images can be uploaded";
        public static string AuthorizationDenied= "You are not authorized to access!";
        public static string UserRegistered="User registered";
        public static string UserNotFound="User not Found";
        public static string PasswordError="Password is not true!";
        public static string SuccessfulLogin="Successful Login";
        public static string UserAlreadyExists="User already Exists";
        public static string AccessTokenCreated="Access Token Created";
    }
}
