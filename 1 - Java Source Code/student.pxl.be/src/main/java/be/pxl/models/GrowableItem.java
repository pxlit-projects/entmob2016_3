package be.pxl.models;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Set;

/**
 * Created by aless on 14/10/2016.
 */

@Entity
@Table(name="GROWABLE_ITEMS")
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

/*    public Set<GrowableItem> getGrowableItems(à) {
        return growableitems;
    }*/
}