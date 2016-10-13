using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using VegiSens.DAL;

namespace VegiSens.DAL.Migrations
{
    [DbContext(typeof(VegiSensContext))]
    partial class VegiSensContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("VegiSens.domain.GrowableItem", b =>
                {
                    b.Property<int>("GrowableItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("HumidityID");

                    b.Property<string>("ImagePath");

                    b.Property<int>("LightID");

                    b.Property<string>("Name");

                    b.Property<int>("TemperatureID");

                    b.HasKey("GrowableItemID");
                });

            modelBuilder.Entity("VegiSens.domain.Humidity", b =>
                {
                    b.Property<int>("HumidityID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("MaxHumidity");

                    b.Property<double>("MinHumidity");

                    b.HasKey("HumidityID");
                });

            modelBuilder.Entity("VegiSens.domain.Light", b =>
                {
                    b.Property<int>("LightID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("MaxLight");

                    b.Property<double>("MinLight");

                    b.HasKey("LightID");
                });

            modelBuilder.Entity("VegiSens.domain.Temperature", b =>
                {
                    b.Property<int>("TemperatureID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("MaxTemperature");

                    b.Property<double>("MinTemperature");

                    b.HasKey("TemperatureID");
                });

            modelBuilder.Entity("VegiSens.domain.GrowableItem", b =>
                {
                    b.HasOne("VegiSens.domain.Humidity")
                        .WithMany()
                        .HasForeignKey("HumidityID");

                    b.HasOne("VegiSens.domain.Light")
                        .WithMany()
                        .HasForeignKey("LightID");

                    b.HasOne("VegiSens.domain.Temperature")
                        .WithMany()
                        .HasForeignKey("TemperatureID");
                });
        }
    }
}
