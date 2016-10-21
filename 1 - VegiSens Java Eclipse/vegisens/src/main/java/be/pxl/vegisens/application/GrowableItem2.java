package be.pxl.vegisens.application;

import java.io.Serializable;
import javax.persistence.*;


public class GrowableItem2 implements Serializable 
{
    private int GrowableItemID;

    private Humidity Humidity;
   
    private Temperature Temperature;
    
    private String Name;

    private String Description;

    private String Image;

	public int getGrowableItemID() {
		return GrowableItemID;
	}

	public void setGrowableItemID(int growableItemID) {
		GrowableItemID = growableItemID;
	}

	public Humidity getHumidity() {
		return Humidity;
	}

	public void setHumidity(Humidity humidity) {
		Humidity = humidity;
	}

	public Temperature getTemperature() {
		return Temperature;
	}

	public void setTemperature(Temperature temperature) {
		Temperature = temperature;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}

	public String getDescription() {
		return Description;
	}

	public void setDescription(String description) {
		Description = description;
	}

	public String getImage() {
		return Image;
	}

	public void setImage(String image) {
		Image = image;
	}


}
