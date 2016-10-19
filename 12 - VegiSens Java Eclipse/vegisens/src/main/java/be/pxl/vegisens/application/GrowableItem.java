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
    private int id;

    @Column(name="NAME")
    private String name;

    @Column(name="DESCRIPTION")
    private String description;

    @Column(name="IMAGE")
    private String image;

    @Column(name="TEMPERATURE_FK")
    private int temperature_fk;

    @Column(name="HUMIDITY_FK")
    private int humidity_Fk;

	public int getId() {
		return id;
	}

	public String getName() {
		return name;
	}

	public String getDescription() {
		return description;
	}

	public String getImage() {
		return image;
	}

	public int getTemperature_fk() {
		return temperature_fk;
	}

	public int getHumidity_Fk() {
		return humidity_Fk;
	}
}
