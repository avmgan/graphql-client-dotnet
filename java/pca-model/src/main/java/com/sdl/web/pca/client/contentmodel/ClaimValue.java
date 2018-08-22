package com.sdl.web.pca.client.contentmodel;

/// <summary>
/// Represents an Ambient Data Framework claim value.
/// </summary>
public class ClaimValue
{
    private ClaimValueType type;
    private String uri;
    private String value;

    public ClaimValue(ClaimValueType type, String uri, String value) {
        this.type = type;
        this.uri = uri;
        this.value = value;
    }

    public ClaimValueType getType()
     {
         return type;
     }
     public void setType(ClaimValueType type)
     {
         this.type = type;
     }

     public String getUri()
     {
         return uri;
     }
     public void setUri(String uri)
     {
         this.uri = uri;
     }

     public String getValue()
     {
         return value;
     }
     public void setValue(String value)
     {
         this.value = value;
     }
}
