package be.pxl.vegisens.application;

import java.io.Serializable;
import javax.persistence.*;


@Entity
@Table(name="growable_items")
public class GrowableItem implements Serializable 
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="ID")
    private int GrowableItemId;

    @ManyToOne
    @JoinColumn(name="HUMIDITY_FK", referencedColumnName="HUMIDITY_ID")
    private Humidity Humidity;
    
    @ManyToOne
    @JoinColumn(name="TEMPERATURE_FK", referencedColumnName="TEMPERATURE_ID")
    private Temperature Temperature;
    
	@Column(name="NAME")
    private String name;

	@Column(name="DESCRIPTION")
    private String Description;

    @Column(name="IMAGE")
    private String Image;

	public int getGrowableItemId() {
		return GrowableItemId;
	}

	public String getName() {
		return name;
	}

	public String getDescription() {
		return Description;
	}

	public Humidity getHumidity() {
		return Humidity;
	}

	public Temperature getTemperature() {
		return Temperature;
	}

	public String getImage() {
		return Image;
	}
	
    public void setGrowableItemId(int growableItemId) {
		this.GrowableItemId = growableItemId;
	}

	public void setHumidity(Humidity humidity) {
		this.Humidity = humidity;
	}

	public void setTemperature(Temperature temperature) {
		this.Temperature = temperature;
	}

	public void setName(String name) {
		this.name = name;
	}

	public void setDescription(String description) {
		this.Description = description;
	}

	public void setImage(String image) {
		this.Image = image;
	}
}
