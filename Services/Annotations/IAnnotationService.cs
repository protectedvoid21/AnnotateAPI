﻿using Data.Models;

namespace Services.Annotations; 

public interface IAnnotationService {
    Task AddAsync(string authorId, string description, IEnumerable<Tuple<int, int>> coordinates);

    Task<IEnumerable<Annotation>> GetAllForPicture(int pictureId);
}