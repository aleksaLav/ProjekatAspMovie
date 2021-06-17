﻿using EfDataAccess;
using EfDataAccess.Migrations;
using MovieShop.Application.Commands;
using MovieShop.Application.Dto;
using MovieShop.Domain;
using MovieShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using System.Linq;

namespace MovieShop.Implementation.Commands
{
    public class EfCreateMovieReservation : ICreateMovieReservationCommand
    {
        private readonly MovieContext context;
        private readonly AddReservationValidator validator;

        public EfCreateMovieReservation(MovieContext context, AddReservationValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 7;

        public string Name => "Ef create reservation";

        public void Execute(MovieReservationDto request)
        {
            validator.ValidateAndThrow(request);

            var movieId = request.MovieId;

            var reservation = new MovieReservation
            {
                MovieId = request.MovieId,
                UserId = request.UserId,
                ReservationDate = DateTime.Now
            };

            context.MovieReservations.Add(reservation);

            var movie = context.Movies.Where(m => m.Id == movieId).FirstOrDefault();
            movie.OnStock -= 1;

            context.SaveChanges();
        }
    }
}
