package com.axity.users.service.util;

import org.springframework.kafka.support.serializer.JsonSerializer;

import com.axity.users.commons.request.MessageDto;

/**
 * Message Serializer class
 * 
 * @author alejandro.menchaca@axity.com
 */
public class MessageSerializer extends JsonSerializer<MessageDto>
{

}
