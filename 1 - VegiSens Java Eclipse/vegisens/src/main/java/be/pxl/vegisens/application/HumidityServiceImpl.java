package be.pxl.vegisens.application;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@Transactional
public class HumidityServiceImpl implements IHumidityService
{

	@Autowired
	HumidityRepository repository;
	
	public Humidity addHumidity(Humidity humidityToAdd)
	{
		double minHumidity = humidityToAdd.getMinHumidity();
		
		//Set ID of humidity
		int humId = 0;
		
		switch ((int)minHumidity)
		{
		case 0: humId = 1;
				 humidityToAdd.setHumidityId(humId);
			break;
		case 30: humId = 2;
				 humidityToAdd.setHumidityId(humId);
			break;
		case 50: humId = 3;
				 humidityToAdd.setHumidityId(humId);
			break;
		case 60: humId = 4;
				 humidityToAdd.setHumidityId(humId);
			break;
		default:
			break;
		}
	
		//Save method uses the PK to check if it already exists, no: create new ,yes: update
		return repository.save(humidityToAdd);
	}

	public Humidity updateHumidity(Humidity humidityToUpdate) 
	{
		return repository.save(humidityToUpdate);
	}

}
