using HW_4_6_Module.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace HW_4_6_Module
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new DataBaseContext())
            {
                //Вывести название песни, имя исполнителя, название жанра песни.
                //Вывести только песни у которых есть жанр и которые поет существующий исполнитель.

                var result1 = from sa in dbContext.SongArtists
                              join a in dbContext.Artist on sa.ArtistId equals a.Id
                              join s in dbContext.Song on sa.ArtistId equals s.Id
                              join g in dbContext.Genre on s.GenreId equals g.Id
                              where a.DateOfDeath == null && s.GenreId != null
                              select new
                              {
                                  songName = s.Title,
                                  artistName = a.Name,
                                  genreName = g.Title
                              };
                foreach (var s in result1)
                {
                    Console.WriteLine($"{s.songName} | {s.artistName} | {s.genreName}");
                }

                ////Вывести кол-во песен в каждом жанре

                var genreSong = from song in dbContext.Song
                                join genre in dbContext.Genre
                                on song.GenreId equals genre.Id
                                group song by new
                                {
                                    s = song.GenreId,
                                    genre.Title
                                };

                foreach (var s in genreSong)
                {
                    Console.WriteLine($"{s.Key.Title} | {s.Count()}");
                }

                // Вывести песни, которые были написаны (ReleasedDate) до рождения самого молодого исполнителя.

                var youngArt = (from art in dbContext.Artist
                                orderby art.DateOfBirth descending
                                select art).FirstOrDefault();

                var res2 = from song in dbContext.Song
                           where song.ReleasedDate < youngArt.DateOfBirth
                           select song.Title;

                foreach (var s in res2)
                {
                    Console.WriteLine($"{s}");
                }
            }
        }
    }
}