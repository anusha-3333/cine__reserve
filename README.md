# CineReserve 🎬

CineReserve is a full-stack movie ticket booking system built using Angular and ASP.NET Core Web API.

## Tech Stack

Frontend: Angular, HTML, CSS, TypeScript  
Backend: ASP.NET Core Web API (C#)  
Database: MySQL  

## Project Structure

cinereserve-ui → Angular Frontend  
CineReserveSolution → ASP.NET Backend  

## Features

- User registration and login (JWT authentication)
- Browse movies
- View movie details
- Seat selection and booking
- Booking history
- Admin can add/update/delete movies
- Admin can manage shows and bookings

## Authentication

- JWT-based authentication
- Role-based access (User / Admin)

## Setup Instructions

### Frontend
cd cinereserve-ui  
npm install  
ng serve  

Runs on: http://localhost:4200  

### Backend
cd CineReserveSolution  
dotnet restore  
dotnet run  

Runs on: https://localhost:5001  

## Database

- Create MySQL database  
- Update connection string in appsettings.json  

## Author

Anusha Dharpal  

## Status

Frontend complete  
Backend complete  
Integration done  
Ready for testing / deployment  
