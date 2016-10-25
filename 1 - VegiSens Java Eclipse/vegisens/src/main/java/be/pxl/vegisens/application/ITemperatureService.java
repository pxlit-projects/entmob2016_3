package be.pxl.vegisens.application;

public interface ITemperatureService
{
	Temperature addTemperature(Temperature temperatureToAdd);
	Temperature updateTemperature(Temperature temperatureToUpdate);
}
