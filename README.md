# Watermarking

This is an implementation of research paper.
For the simplification I have assumed (250 x 250) grayscale images. The data is embedded inside an image and later that data is extracted back from the image easily without any quality degradation in original image. This lossless recovery is useful in applications where security concern arises such as medical image analysis, forensics, military images, etc.


Given a grayscale photograph as input, the application creates a watermark from image and tries to embed it inside LSB of the image. This watermark is recovered on the receiving side without any loss in data as we have a Difference Map image displayed in black which ensures data is correct. If the image is tampered, the difference will be visible in the Difference map image.
