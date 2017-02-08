# TSK_XML_1
Xml read write


Information to come...


Code

XmlDocument is very easy to use. Its only real drawback is that it loads the whole XML document into memory to process. Its seductively simple to use.

XmlReader is a stream based reader so will keep your process memory utilization generally flatter but is more difficult to use.

XPathDocument tends to be a faster, read-only version of XmlDocument, but still suffers from memory 'bloat'.
