package be.pxl.vegisens.application;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class TemperatureServiceImpl implements ITemperatureService {

	@Autowired
	TemperatureRepository repository;
	
	public Temperature addTemperature(Temperature temperatureToAdd)
	{
		//Test if temperature exists and if it does, give it the id, else create new
		List<Temperature> temperatureList = (List<Temperature>) repository.findAll();
		
		double minTemperature = temperatureToAdd.getMinTemperature();
		double maxTemperature = temperatureToAdd.getMaxTemperature();
		
		for (Temperature temperature : temperatureList)
		{
			if(temperature.getMinTemperature() == minTemperature && temperature.getMaxTemperature() == maxTemperature)
			{
				int tempId = temperature.getTemperatureId();
				temperatureToAdd.setTemperatureId(tempId);
			}
		}
		
		//Save method uses the PK to check if it already exists, no: create new ,yes: update
		return repository.save(temperatureToAdd);
	}

	public Temperature updateTemperature(Temperature temperatureToUpdate) 
	{
		return repository.save(temperatureToUpdate);
	}

}
