package be.pxl.vegisens.application;

import java.io.Serializable;
import javax.persistence.*;


@Entity
@Table(name="growable_items")
public class GrowableItemEntity implements Serializable 
{
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="ID")
    private int growableItemId;
    
	@Column(name="NAME")
    private String name;

	@Column(name="DESCRIPTION")
    private String description;

    @Column(name="IMAGE")
    private String image;
    
    @Column(name="TEMPERATURE_FK")
    private int temperature_fk;
    
    @Column(name="HUMIDITY_FK")
    private int humidity_fk;

	public int getGrowableItemId() {
		return growableItemId;
	}

	public void setGrowableItemId(int growableItemId) {
		this.growableItemId = growableItemId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public int getTemperature_fk() {
		return temperature_fk;
	}

	public void setTemperature_fk(int temperature_fk) {
		this.temperature_fk = temperature_fk;
	}

	public int getHumidity_fk() {
		return humidity_fk;
	}

	public void setHumidity_fk(int humidity_fk) {
		this.humidity_fk = humidity_fk;
	}

	public String toString()
	{
		return "[GrowableItemID]: " + this.growableItemId + 	
			   " [Name]: " + this.name +
			   " [Description]: " + this.description +
			   " [Humidity_FK]: " + this.humidity_fk + 	
			   " [Temperature_FK]: " + this.temperature_fk;
	}
}
