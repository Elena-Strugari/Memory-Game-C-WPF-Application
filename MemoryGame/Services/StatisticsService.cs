using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemoryGame.Services
{

    public static class StatisticsService
    {
        private static readonly string StatisticsFile = "statistics.json";

        public static Statistics LoadStatistics()
        {
            if (!File.Exists(StatisticsFile))
            {
                return new Statistics();
            }

            var json = File.ReadAllText(StatisticsFile);
            return JsonSerializer.Deserialize<Statistics>(json);
        }

        public static void SaveStatistics(Statistics stats)
        {
            var json = JsonSerializer.Serialize(stats, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(StatisticsFile, json);
        }
        public static void DeleteStatisticsByUser(string username)
        {
            string statisticsFile = "statistics.json";
            if (!File.Exists(statisticsFile)) return;

            var statistics = JsonSerializer.Deserialize<List<Statistics>>(File.ReadAllText(statisticsFile));
            statistics.RemoveAll(s => s.Username == username);
            File.WriteAllText(statisticsFile, JsonSerializer.Serialize(statistics, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
