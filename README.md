# TSK_XML_1
Xml read write


Information to come...


Code

XmlDocument is very easy to use. Its only real drawback is that it loads the whole XML document into memory to process. Its seductively simple to use.

XmlReader is a stream based reader so will keep your process memory utilization generally flatter but is more difficult to use.

XPathDocument tends to be a faster, read-only version of XmlDocument, but still suffers from memory 'bloat'.

NOTE!!


No. The XmlDocument class does not implement IDisposable, so there is no way to force it to release it's resources at will. If you really need to immediately free the memory used by XmlDocument, the only way to do that would be to do the following:

nodes = null;
xml = null;
GC.Collect();

The garbage collector works on a separate thread, so it may still not happen immediately. To force the garbage collection to occur synchronously, before continuing execution of your code, you must also call WaitForPendingFinalizers, as such:

nodes = null;
xml = null;
GC.Collect();
GC.WaitForPendingFinalizers();

XmlDocument always loads the entire document into memory at once. If you simply want to iterate through the nodes in the document as a stream, only loading a bit at a time, that is what the XmlReader class is for. However, you lose a lot of functionality that way. For instance, there is no way to select nodes via XPath, as you where doing in your example. With XmlReader, you have to write your own logic to determine where in the document you are and whether that matches what you are looking for.

