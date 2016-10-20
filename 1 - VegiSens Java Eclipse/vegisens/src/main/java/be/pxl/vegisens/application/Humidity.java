package be.pxl.vegisens.application;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.*;


@Entity
@Table(name="humidity")
public class Humidity implements Serializable 
{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name="HUMIDITY_ID")
    private int humidityId;
   
    @OneToMany(mappedBy="humidity")
    private List<GrowableItem> growableItems = new ArrayList<GrowableItem>();
    
	@Column(name="MIN_IDEAL_HUMIDITY")
    private double minHumidity;

    @Column(name="MAX_IDEAL_HUMIDITY")
    private double maxHumidity;

	public int getHumidityId() {
		return humidityId;
	}

	public double getMinHumidity() {
		return minHumidity;
	}

	public double getMaxHumidity() {
		return maxHumidity;
	}
}
