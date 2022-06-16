using Airplane_Reservation;
using Airplane_Reservation.Models;
using static Airplane_Reservation.SeatingAlgorithm.FillSeats;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

char[,] seats = new char[GlobalConstants.AeroplaneRow, GlobalConstants.AeroplaneColumn];
for (int i = 0; i < GlobalConstants.AeroplaneRow; i++)
{
    seats[i, 0] = GlobalConstants.AisleSeat;
    seats[i, 1] = GlobalConstants.MiddleSeat;
    seats[i, 2] = GlobalConstants.WindowSeat;
}

app.MapPost("/BookTickets", (string seatNumber) =>
{
    return BookSeats(seats, seatNumber);
})
.WithName("Book Tickets");


app.MapGet("/ViewAvailabeleSeats", () =>
{
    return ViewAvailabeleSeats(seats);
})
.WithName("View Available Seats");


app.MapGet("/ViewSeatStatus", (string seatNumber) =>
{
    return ViewSeatStatus(seats, seatNumber);
})
.WithName("View Seat Status");


app.MapPost("/CancelTicket", (string seatNumber) =>
{
    return CancelTickets(seats, seatNumber);        
})
.WithName("Cancel Ticket");

app.Run();

