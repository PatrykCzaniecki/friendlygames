﻿using System.ComponentModel.DataAnnotations.Schema;
using FriendlyGames.Domain.Enums;

namespace FriendlyGames.Domain.Models;

public class Registration
{
    [ForeignKey(nameof(EventId))] public Event Event { get; set; } = null!;
    public int EventId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; } = null!;
    public string UserId { get; set; }
    public DateTime RegistrationDateTime { get; set; } = DateTime.Now;

    [ForeignKey(nameof(RegistrationCategoryId))]
//formatowanie do usuneica ta spacja pomiedzy atrybutem a propertisem
    public int RegistrationCategoryId { get; set; }
}
