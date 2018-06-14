﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SymJumbles.Models;
using System;

namespace SymJumbles.Migrations
{
    [DbContext(typeof(SymJumblesContext))]
    [Migration("20180614165156_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("SymJumbles.Models.IncomingMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountSid");

                    b.Property<string>("ApiVersion");

                    b.Property<string>("Body");

                    b.Property<string>("From");

                    b.Property<string>("FromCity");

                    b.Property<string>("FromCountry");

                    b.Property<string>("FromState");

                    b.Property<string>("FromZip");

                    b.Property<string>("MessageSid");

                    b.Property<string>("NumMedia");

                    b.Property<string>("NumSegments");

                    b.Property<string>("SmsMessageSid");

                    b.Property<string>("SmsSid");

                    b.Property<string>("SmsStatus");

                    b.Property<string>("To");

                    b.Property<string>("ToCity");

                    b.Property<string>("ToCountry");

                    b.Property<string>("ToState");

                    b.Property<string>("ToZip");

                    b.HasKey("ID");

                    b.ToTable("IncomingMessage");
                });

            modelBuilder.Entity("SymJumbles.Models.Jumble", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MessageIn");

                    b.Property<string>("MessageOut");

                    b.Property<string>("NumberFrom");

                    b.Property<string>("NumberTo");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("ID");

                    b.ToTable("Jumble");
                });
#pragma warning restore 612, 618
        }
    }
}
