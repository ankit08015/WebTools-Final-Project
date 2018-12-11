using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WordDaze.Shared.Models
{
    public class UserBost
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Posted { get; set; }
        public string Post { get; set; }
        public string PostSummary
        {
            get
            {
                if (Post?.Length > 50)
                    return Post.Substring(0, 50);

                return Post;
            }
        }
    }
}
