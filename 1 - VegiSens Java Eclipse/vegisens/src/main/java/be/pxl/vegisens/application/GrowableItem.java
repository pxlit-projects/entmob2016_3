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
}
