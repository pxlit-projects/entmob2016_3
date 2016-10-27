package be.pxl.vegisens.application;

import java.io.Serializable;
import javax.persistence.*;


@Entity
@Table(name="growable_items")
public class GrowableItem implements Serializable 
{
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="ID")
    private int growableItemId;

    @ManyToOne
    @JoinColumn(name="HUMIDITY_FK", referencedColumnName="HUMIDITY_ID")
    private Humidity humidity;
    
    @ManyToOne
    @JoinColumn(name="TEMPERATURE_FK", referencedColumnName="TEMPERATURE_ID")
    private Temperature temperature;
    
	@Column(name="NAME")
    private String name;

	@Column(name="DESCRIPTION")
    private String description;

    @Column(name="IMAGE")
    private String image;

	public int getGrowableItemId() {
		return growableItemId;
	}

	public String getName() {
		return name;
	}

	public String getDescription() {
		return description;
	}

	public Humidity getHumidity() {
		return humidity;
	}

	public Temperature getTemperature() {
		return temperature;
	}

	public String getImage() {
		return image;
	}
	
    public void setGrowableItemId(int growableItemId) {
		this.growableItemId = growableItemId;
	}

	public void setHumidity(Humidity humidity) {
		this.humidity = humidity;
	}

	public void setTemperature(Temperature temperature) {
		this.temperature = temperature;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public void setImage(String image) {
		this.image = image;
	}
	
	public String toString()
	{
		return "[GrowableItemID]: " + this.growableItemId +
			   " [Name]: " + this.name +
			   " [Description]: " + this.description +
			   " [Image]: " + this.image + 	
			   " [Temperature]: " + this.temperature.toString() + 	
			   " [Humidity]: " + this.humidity.toString();
	}
}
